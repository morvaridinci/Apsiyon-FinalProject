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
    public class BlockService : IBlockService
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IMapper _mapper;

        public BlockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(BlockViewDto entity)
        {
            await _unitOfWork.Block.Add(new Block {
                BlockName = entity.BlockName
            });
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = (await _unitOfWork.Block.Get(x => x.Id == id)).FirstOrDefault();
            _unitOfWork.Block.Delete(entityToDelete);
        }

        public async Task<List<BlockViewDto>> Get(Expression<Func<BlockViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Block, bool>>>(filter);

            var result = await _unitOfWork.Block.Get(dtoFilter);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<List<BlockViewDto>>(result);
        }

        public async Task<List<BlockViewDto>> GetAll()
        {
            var result = await _unitOfWork.Block.GetAll();
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<List<BlockViewDto>>(result);
        }

       
    }
}
