using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IUnitOfWork
    {
        IApartmentRepository Apartment { get; }
        IBlockRepository Block { get; }
        IBillRepository Bill { get; }
        IDebtTypeRepository DebtType { get; }
        IUserRepository User { get; }
        IMessageRepository Message { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
