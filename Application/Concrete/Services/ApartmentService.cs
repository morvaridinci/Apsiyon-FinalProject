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
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IMapper _mapper;
        public ApartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Add(ApartmentAddViewDto apartment)
        {

            await _unitOfWork.Apartment.Add(_mapper.Map<Apartment>(apartment));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var apartmentToDelete = (await _unitOfWork.Apartment.Get(x => x.Id == id)).FirstOrDefault();
            _unitOfWork.Apartment.Delete(apartmentToDelete);
        }

        public async Task<List<ApartmentViewDto>> Get(Expression<Func<ApartmentViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Apartment, bool>>>(filter);

            var result = await _unitOfWork.Apartment.Get(dtoFilter);

            return _mapper.Map<List<ApartmentViewDto>>(result);
        }

        public async Task<List<ApartmentViewDto>> GetAll()
        {
            var result = await _unitOfWork.Apartment.GetAll();
            return _mapper.Map<List<ApartmentViewDto>>(result); 
        }

      

        public async Task<ApartmentViewDto> GetById(int id)
        {
            var result = (await _unitOfWork.Apartment.Get(x => x.Id == id)).FirstOrDefault();
            if (result != null)
            {
                return _mapper.Map<ApartmentViewDto>(result);
            }
            return null;
        }

        public async Task Update(ApartmentViewDto entity)
        {
            var updatedApartment = (await _unitOfWork.Apartment.Get(x => x.Id == entity.Id)).FirstOrDefault();
            updatedApartment.Owner.Name = entity.Owner.Name;
            updatedApartment.Status = entity.Status;
            updatedApartment.Floor = entity.Floor;
            updatedApartment.Type = entity.Type;
            updatedApartment.ApartmentNumber = entity.ApartmentNumber;
            _unitOfWork.Apartment.Update(updatedApartment);
            await _unitOfWork.SaveChangesAsync();


        }
    }
}
