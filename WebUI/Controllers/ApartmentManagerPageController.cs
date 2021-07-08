using Application.Abstract;
using Application.Concrete.Dtos;
using Domain.Concrete;
using Infrastructure.Data.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ApartmentManagerPage.Controllers
{
    [Authorize(Roles="ApartmentManager")]
    public class ApartmentManagerPageController : Controller
    {

        private readonly IUserService _userService;
        private readonly IApartmentService _apartmentService;
        private readonly IDebtTypeService _debtTypeService;
        private readonly IBlockService _blockService;
        private readonly IBillService _billService;
        private readonly IMessageService _messageService;

        private readonly UserManager<User> _userManager;

        public ApartmentManagerPageController(UserManager<User> userManager, IUserService userService, IApartmentService apartmentService, IBlockService blockService, IDebtTypeService debtTypeService, IBillService billService, IMessageService messageService)
        {
            _userService = userService;
            _apartmentService = apartmentService;
            _blockService = blockService;
            _userManager = userManager;
            _debtTypeService = debtTypeService;
            _billService = billService;
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserAddViewDto model)
        {
            

            await _userManager.CreateAsync(new User
            {
                Name = model.Name,
                Surname = model.Surname,
                TC = model.TC,
                Email = model.Email,
                UserName = model.UserName,
                Address = model.Address,
                Province = model.Province,
                CarExist = model.CarExist,
                NumberPlate = model.NumberPlate,
                PhoneNumber = model.PhoneNumber

            }, model.Password);
            var user = await _userManager.FindByEmailAsync(model.Email);
           if(user != null)
            {
               
                if (!await _userManager.IsInRoleAsync(user, Roles.OtherUser))
                    await _userManager.AddToRoleAsync(user, Roles.OtherUser);
            }

            await _userService.Add(model);
            return RedirectToAction("AddUser");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var userViewDto = await _userService.GetAll();
          
            return View(userViewDto);
        }

        [HttpGet]
        public async Task<IActionResult> AddApartment()
        {
            List<BlockViewDto> blockViewDto = await _blockService.GetAll();
            ViewBag.Block = blockViewDto;
            ViewBag.User = _userManager.Users.ToList();

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddBill()
        {
            List<ApartmentViewDto> apartmentViewDto = await _apartmentService.GetAll();
            List<DebtTypeViewDto> debtViewDto = await _debtTypeService.GetAll();
            List<BlockViewDto> blockViewDto = await _blockService.GetAll();


            ViewBag.DebtType = debtViewDto;
            ViewBag.Apartment = apartmentViewDto;
            ViewBag.Block = blockViewDto;
            ViewBag.User = _userManager.Users.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBill(BillAddViewDto billAddViewDto)
        {
            List<BlockViewDto> blockViewDto = await _blockService.GetAll();
            await _billService.Add(billAddViewDto);
            return RedirectToAction("AddBill");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBills()
        {
            List<BillViewDto> billViewDto = await _billService.GetAll();
            return View(billViewDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment(ApartmentAddViewDto model)
        {

            await _apartmentService.Add(model);

            return RedirectToAction("AddApartment");
        }


        [HttpGet]
        public IActionResult UpdateApartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateApartment(ApartmentViewDto model)
        {
            await _apartmentService.Update(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteApartment(ApartmentViewDto model)
        {
            await _apartmentService.Delete(model);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApartments()
        {

            List<ApartmentViewDto> apartmentViewDto = await _apartmentService.GetAll();
            return View(apartmentViewDto);

        }
        [HttpGet]
        public IActionResult AddBlock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlock(BlockViewDto blockViewDto)
        {
            await _blockService.Add(blockViewDto);
            return View(blockViewDto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteBlock(BlockViewDto blockViewDto)
        {
            await _blockService.Delete(blockViewDto);
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> GetAllBlocks()
        {
            List<BlockViewDto> blockViewDto = await _blockService.GetAll();
            return View(blockViewDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            List<MessageViewDto> messages = await _messageService.GetAll();
            return View(messages);
        }


        [HttpGet]
        public IActionResult UpdateBill()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBill(BillViewDto billViewDto)
        {
             await _billService.Update(billViewDto);
            return View(billViewDto);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBill(BillViewDto billViewDto)
        {
            await _billService.Delete(billViewDto);
            return View();
        }
    }

}

