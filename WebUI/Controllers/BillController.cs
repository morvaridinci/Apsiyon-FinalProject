using Application.Abstract;
using Application.Concrete.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillService _billService;
        private readonly IDebtTypeService _debtTypeService;
        private readonly IApartmentService _apartmentService;

        public BillController(IBillService billService,IApartmentService apartmentService)
        {
            _billService = billService;
            _apartmentService = apartmentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBills()
        {
            List<BillViewDto> billViewDto = await _billService.GetAll();
            return View(billViewDto);
        }


        [HttpGet]
        public IActionResult UpdateBill()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateBill(BillViewDto billViewDto)
        //{
        //    var billToUpdate = await _billService.Update(billViewDto);
        //    return View(billToUpdate);
        //}

        //[HttpGet]
        //public async Task<IActionResult> DeleteBill(BillViewDto billViewDto)
        //{
        //    await _apartmentService.Delete(billViewDto);
        //    return View();
        //}
    }
}
