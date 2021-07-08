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
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IMapper _mapper;

        public BillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(BillAddViewDto entity)
        {
            await _unitOfWork.Bill.Add(_mapper.Map<Bill>(entity));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var billToDelete = (await _unitOfWork.Bill.Get(x => x.Id == id)).FirstOrDefault();
            _unitOfWork.Bill.Delete(billToDelete);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<BillViewDto>> Get(Expression<Func<BillViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Bill, bool>>>(filter);

            var result = await _unitOfWork.Bill.Get(dtoFilter);

            return _mapper.Map<List<BillViewDto>>(result);

        }

        public async Task<List<BillViewDto>> GetAll()
        {
            var result = await _unitOfWork.Bill.GetAll();

            return _mapper.Map<List<BillViewDto>>(result);
        }

        public async Task Update(BillViewDto billViewDto)
        {
            var billToUpdate = (await _unitOfWork.Bill.Get(x => x.Id == billViewDto.Id)).FirstOrDefault();
            billViewDto.Amount = billToUpdate.Amount;
            billViewDto.BillDate = billToUpdate.BillDate;
            billViewDto.BillStatus = billToUpdate.BillStatus;

            _unitOfWork.Bill.Update(_mapper.Map<Bill>(billViewDto));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
