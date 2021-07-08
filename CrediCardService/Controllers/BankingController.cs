using CreditCardService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BankingController : ControllerBase
    {
        private readonly Services.CreditCardService _creditCardService;
        public BankingController(Services.CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost("WithdrawMoney")]
        public async Task<IActionResult> WithdrawMoney(CreditCardViewModel model)
        {
            var result = await _creditCardService.WithdrawMoney(new Models.MongoDb.CreditCard
            {
                CardNumber = model.CardNumber,
                Cvv = model.Cvv,
                Owner = model.Owner,
                ValidMounth = model.ValidMonth,
                ValidYear = model.ValidYear
            }, model.Money);
            return Ok(result);
        }
    }
}
