using Domain.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
    public class BillAddViewDto
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int BlockId { get; set; }
        public int DebtTypeId { get; set; }
        public string OwnerId { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
    }
}
