using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Concrete;
using Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Infrastructure.Data.Concrete.EntityFramework
{

    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        
        public ApartmentRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
