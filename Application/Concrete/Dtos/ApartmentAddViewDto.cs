using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
    public class ApartmentAddViewDto
    {
        public int Id { get; set; }
        public int ApartmentNumber { get; set; }
        public int BlockId { get; set; }
        public string OwnerId { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
    }
}
