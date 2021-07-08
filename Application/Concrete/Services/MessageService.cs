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
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(MessageViewDto entity)
        {
            await _unitOfWork.Message.Add(_mapper.Map<Message>(entity));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var messageToDelete = (await _unitOfWork.Message.Get(x => x.Id == id)).FirstOrDefault();
            _unitOfWork.Message.Delete(messageToDelete);
        }

        public async Task<List<MessageViewDto>> Get(System.Linq.Expressions.Expression<Func<MessageViewDto, bool>> filter)
        {
            var dtoFilter = _mapper.Map<Expression<Func<Message, bool>>>(filter);

            var result = await _unitOfWork.Message.Get(dtoFilter);

            return _mapper.Map<List<MessageViewDto>>(result);
        }

        public async Task<List<MessageViewDto>> GetAll()
        {
            var result = await _unitOfWork.Message.GetAll();
            return _mapper.Map<List<MessageViewDto>>(result);
        }

    }
}
