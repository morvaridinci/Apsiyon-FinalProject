using Application.Abstract;
using Application.Concrete.Dtos;
using AutoMapper;
using Domain.Abstract;
using Domain.Concrete;
using Infrastructure.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Services
{
    public class DebtTypeService : IDebtTypeService
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IMapper _mapper;

        public DebtTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(DebtTypeViewDto entity)
        {
            await _unitOfWork.DebtType.Add(new DebtType { 
              Name = entity.Name
            });
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(DebtTypeViewDto debtTypeViewDto)
        {
            var entityToDelete = (await _unitOfWork.DebtType.Get(x => x.Id == debtTypeViewDto.Id)).FirstOrDefault();
            _unitOfWork.DebtType.Delete(entityToDelete);
            await _unitOfWork.SaveChangesAsync();
        }
        

        public async Task<List<DebtTypeViewDto>> Get(Expression<Func<DebtTypeViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<DebtType, bool>>>(filter);

            var result = await _unitOfWork.DebtType.Get(dtoFilter);

            return _mapper.Map<List<DebtTypeViewDto>>(result);
        }

        public async Task<List<DebtTypeViewDto>> GetAll()
        {
            var result = await _unitOfWork.DebtType.GetAll();

            return _mapper.Map<List<DebtTypeViewDto>>(result);
        }
    }
}
