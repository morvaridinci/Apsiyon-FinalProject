using Domain.Abstract;
using Infrastructure.Data.Concrete;
using Infrastructure.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Abstract
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApartmentRepository Apartment { get; }

        public IBlockRepository Block { get; }

        public IBillRepository Bill { get; }

        public IUserRepository User { get; }
        public IMessageRepository Message { get; }

        public IDebtTypeRepository DebtType { get; }


        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context, IApartmentRepository apartment, IBlockRepository block, IBillRepository bill, IDebtTypeRepository debtType,IUserRepository user, IMessageRepository message)
        {
            _context = context;
            Apartment = apartment;
            DebtType = debtType;
            Bill = bill;
            Block = block;
            User = user;
            Message = message;
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
