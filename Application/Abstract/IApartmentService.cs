using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IApartmentService
    {
        Task Add(ApartmentAddViewDto entity);
        Task Delete(int id);
        Task Update(ApartmentViewDto entity);
        Task<List<ApartmentViewDto>> GetAll();
        Task<List<ApartmentViewDto>> Get(Expression<Func<ApartmentViewDto, bool>> filter);

    }
}
