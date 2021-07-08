
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TC { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public bool CarExist { get; set; }
        public string NumberPlate { get; set; }
        public virtual Apartment Apartment { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
