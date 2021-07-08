using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
   public class BillGetAllViewDto
    {
        public int Id { get; set; }
        public DebtTypeViewDto DebtType { get; set; }
        public UserViewDto User { get; set; }
        public ApartmentViewDto Apartment { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public bool BillStatus { get; set; }
    }
}
