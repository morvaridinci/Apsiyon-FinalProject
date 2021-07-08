using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IBlockService 
    {
        Task Add(BlockViewDto entity);
        Task Delete(int id);
        Task<List<BlockViewDto>> GetAll();
        Task<List<BlockViewDto>> Get(Expression<Func<BlockViewDto, bool>> filter);
    }
}
