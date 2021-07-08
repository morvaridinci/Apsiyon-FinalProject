using Application.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface ICreditCardService
    {
        Task<bool> WithdrawMoney(CreditCardDto creditCard);
    }
}
