using Application.Concrete.Dtos;
using Domain.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Application.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WebUI.Controllers
{
    public class OtherUserPageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ICreditCardService _creditCardService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public OtherUserPageController(IMessageService messageService, UserManager<User> userManager, SignInManager<User> signInManager, ICreditCardService creditCardService)
        {
            _messageService = messageService;
            _signInManager = signInManager;
            _userManager = userManager;
            _creditCardService = creditCardService;
        }

        //[Authorize(Roles = "OtherUser")]
        [AuthorizeByRole(Roles.OtherUser)]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllBills()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageViewDto model)
        {
            // LoginViewModel loginViewModel = new LoginViewModel();

            //var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

            // var user = await _userManager.FindByEmailAsync(loginViewModel.UserName);
            // ViewBag.User = user.UserName;
            await _messageService.Add(model);
            return RedirectToAction("SendMessage");
        }

        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            //var currentUser = HttpContext.Session.Get<User>("user");


            var _currentUserId = TempData["mydata"] as String;
            User user = await _userManager.FindByIdAsync(_currentUserId);
            
            float totalAmount = 0;
            foreach (var bill in user.Apartment.Bills)
            {
                totalAmount += bill.Amount;
            }
            ViewBag.TotalAmount = totalAmount;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Payment(CreditCardDto creditCard)
        {
            
            bool result = await _creditCardService.WithdrawMoney(creditCard);
            return View();
        }

       
    }
}
