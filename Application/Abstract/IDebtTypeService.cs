using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IDebtTypeService
    {
        Task Add(DebtTypeViewDto entity);
        Task Delete(DebtTypeViewDto id);
        Task<List<DebtTypeViewDto>> GetAll();
        Task<List<DebtTypeViewDto>> Get(Expression<Func<DebtTypeViewDto, bool>> filter);
    }
}
