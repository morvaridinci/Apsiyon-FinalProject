using Application.Concrete.Dtos;
using Domain.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Models.Login;

namespace WebUI.Controllers
{
    
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public string _currentUser;
        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public string userId;


        public async Task<IActionResult> AddToRole()
        {
            //Name-UserName
            User user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            //only checks the logged in user 
            //assigns the user to the role if not in the role
            if (!await _userManager.IsInRoleAsync(user, Roles.ApartmentManager))
                await _userManager.AddToRoleAsync(user, Roles.ApartmentManager);

            //makes cookie refresh
            await _signInManager.SignOutAsync();


            return View();
        }


        public async Task<IActionResult> Role()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = Roles.ApartmentManager });
            await _roleManager.CreateAsync(new IdentityRole { Name = Roles.OtherUser });
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
            var user = await _userManager.FindByEmailAsync(loginViewModel.UserName);
            //_currentUser = user.Id;
            ////only checks the logged in user 
            ////assigns the user to the role if not in the role
            if (loginViewModel.UserType == "Yönetici")
            {
                //var user1 = await _userManager.FindByNameAsync(loginViewModel.UserName);
                bool isInRole = await _userManager.IsInRoleAsync(user, Roles.ApartmentManager);
                if (result.Succeeded && isInRole == true)
                {
                   
                    return RedirectToAction("Index", "ApartmentManagerPage");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
           

            else if (loginViewModel.UserType == "Kullanici")
            {
                
                
                bool isInRole = await _userManager.IsInRoleAsync(user, Roles.OtherUser);
                
                if (result.Succeeded && isInRole == true)
                {
                    //HttpContext.Session.Set<User>("user", user);
                    TempData["mydata"] = user.Id;
                    return RedirectToAction("Index", "OtherUserPage");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }

            return View();

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(new Domain.Concrete.User
            {
                Email = model.Email,
                Name = model.Name,
                Surname =model.Surname,
                Address=model.Address,
                Province=model.Province,
                TC = model.TC,
                NumberPlate=model.NumberPlate,
                PhoneNumber=model.PhoneNumber,
                UserName = model.Email,
                CarExist = model.CarExist

            }, model.Password);

            if (result.Succeeded)
            {
                User user = await _userManager.FindByEmailAsync(model.Email);
                if (!await _userManager.IsInRoleAsync(user, Roles.ApartmentManager))
                    await _userManager.AddToRoleAsync(user, Roles.ApartmentManager);
                await _signInManager.SignOutAsync();
            }
            if (!result.Succeeded) return RedirectToAction("Login");

            return View("Index", "ApartmentManagerPage");
        }

       

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
