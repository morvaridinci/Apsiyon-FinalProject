using Domain.Abstract;
using Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Concrete.EntityFramework
{
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        public BillRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
