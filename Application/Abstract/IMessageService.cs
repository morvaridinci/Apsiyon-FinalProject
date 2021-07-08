using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IMessageService
    {
        Task Add(MessageViewDto entity);
        Task Delete(int id);
        Task<List<MessageViewDto>> GetAll();
        Task<List<MessageViewDto>> Get(Expression<Func<MessageViewDto, bool>> filter);
    }
}
