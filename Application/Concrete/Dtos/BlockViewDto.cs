using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete.Dtos
{
    public class BlockViewDto
    {
        public int Id { get; set; }
        public string BlockName { get; set; }
        public ICollection<ApartmentViewDto> Apartments { get; set; }
    }
}
