using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class Block : IEntity
    {
        public int Id { get; set; }
        public string BlockName { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
