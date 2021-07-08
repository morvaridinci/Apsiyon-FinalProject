using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class Bill : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("ApartmentId")]
        public virtual Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public bool BillStatus { get; set; }

        [ForeignKey("DebtTypeId")]
        public virtual DebtType DebtType { get; set; }
        public int DebtTypeId { get; set; }
    }
}
