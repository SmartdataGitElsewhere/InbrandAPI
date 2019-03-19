using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InbrandInterface
{
   public interface IUnitOfWork : IDisposable
    {
        ISubscriptionRepository Subscriptions { get; }
        IUserRepository Users { get; }
        IIPAddressRepository IPAddress { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
