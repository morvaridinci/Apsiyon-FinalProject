using CreditCardService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private JwtService _jwtService;
        //public AuthController(JwtService jwtService)
        //{
        //    _jwtService = jwtService;
        //}
        private IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login(UserViewModel user)
        {
            JwtService jwtService = new JwtService(_configuration);
            string token = string.Empty;
            if (user.UserName == "a" && user.Password == "a")
            {
                token = jwtService.CreateToken();
                return Ok(new { Status = true, Token = token });
            }
            return BadRequest();
        }
    }
}
