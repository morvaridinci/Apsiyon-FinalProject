using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IBillService
    { 
      Task Add(BillAddViewDto entity);
      Task Delete(BillViewDto billViewDto);
      Task Update(BillViewDto billViewDto);
      Task<List<BillViewDto>> GetAll();
      Task<List<BillViewDto>> Get(Expression<Func<BillViewDto, bool>> filter);
    }
}
