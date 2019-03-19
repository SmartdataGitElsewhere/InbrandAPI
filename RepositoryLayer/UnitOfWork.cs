using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InbrandInterface;
using RepositoryLayer.DA;

namespace RepositoryLayer
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly DB db;
        public UnitOfWork()
        {
            db = new DB();
        }


        private ISubscriptionRepository _Subscription;
        private IUserRepository _user;
        private IIPAddressRepository _ipaddress;
        public ISubscriptionRepository Subscriptions
        {
            get
            {
                if (this._Subscription == null)
                    this._Subscription = new SubscriptionRepository(db);
                return this._Subscription;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (this._user == null)
                    this._user = new UserRepository(db);
                return this._user;
            }
        }

        public IIPAddressRepository IPAddress
        {
            get
            {
                if (this._ipaddress == null)
                    this._ipaddress = new IPAddressRepository(db);
                return this._ipaddress;
            }
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
