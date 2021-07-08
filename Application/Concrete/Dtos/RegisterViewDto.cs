using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
    public class RegisterViewDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string TC { get; set; }
        public bool CarExist { get; set; }
        public string Province { get; set; }
        public string PhoneNumber { get; set; }
        public string NumberPlate { get; set; }
        public string Password { get; set; }
    }
}
