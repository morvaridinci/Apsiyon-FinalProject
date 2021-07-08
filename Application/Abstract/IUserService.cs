using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IUserService
    {
        Task Add(UserAddViewDto entity);
        Task Delete(string id);
        Task Update(UserViewDto entity);
        Task<List<UserViewDto>> GetAll();

    }
}
