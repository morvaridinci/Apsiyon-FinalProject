using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
    public class BillViewDto
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int DebtTypeId { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public bool BillStatus { get; set; }
    }
}
