using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class Apartment : IEntity
    {
        public int Id { get; set; }
        public int ApartmentNumber { get; set; }
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
       
        public int BlockId { get; set; }
        [ForeignKey("BlockId")]
        public virtual Block Block { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
       
        public virtual ICollection<Bill> Bills { get; set; }

    }
}
