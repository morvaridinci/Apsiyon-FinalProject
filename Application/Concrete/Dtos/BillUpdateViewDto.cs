using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
    public class BillUpdateViewDto
    {
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public bool BillStatus { get; set; }

    }
}
