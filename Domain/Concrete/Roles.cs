using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public static class Roles
    {
        //To be able to use it as a Roles.ApartmentManager
       
        public const string ApartmentManager = "ApartmentManager";
        public const string OtherUser = "OtherUser";
    }

     public enum ROLES_TYPES : byte
     {
        [Description(Roles.ApartmentManager)]
        ApartmentManager = 1,
        [Description(Roles.OtherUser)]
        OtherUser,
      }
}
