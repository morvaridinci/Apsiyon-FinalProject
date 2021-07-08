using Application.Abstract;
using Application.Concrete.Dtos;
using AutoMapper;
using Domain.Abstract;
using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(UserAddViewDto entity)
        {
           await _unitOfWork.User.Add(new User
            {
                    Name = entity.Name,
                    Surname = entity.Surname,
                    UserName=entity.Email,
                    TC = entity.TC,
                    Email=entity.Email,
                    PasswordHash=entity.Password,
                    Province = entity.Province,
                    Address = entity.Address,
                    CarExist = entity.CarExist,
                    NumberPlate = entity.NumberPlate,
                    PhoneNumber = entity.PhoneNumber,

            });

           await _unitOfWork.SaveChangesAsync();
        }
        public async Task Update(UserViewDto entity)
        {
            _unitOfWork.User.Update(new User
            {
                Name = entity.Name,
                Surname = entity.Surname,
                UserName = entity.Email,
                TC = entity.TC,
                Email = entity.Email,
                PasswordHash = entity.Password,
                Province = entity.Province,
                Address = entity.Address,
                CarExist = entity.CarExist,
                NumberPlate = entity.NumberPlate,
                PhoneNumber = entity.PhoneNumber,

            });

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var entityToDelete = (await _unitOfWork.User.Get(x => x.Id == id)).FirstOrDefault();
            _unitOfWork.User.Delete(entityToDelete);
           await _unitOfWork.SaveChangesAsync();
        }

        

        public async Task<List<UserViewDto>> GetAll()
        {
            var result = await _unitOfWork.User.GetAll();

            return _mapper.Map<List<UserViewDto>>(result);
           
        }


    }
}
