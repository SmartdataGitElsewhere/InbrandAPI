using Inbrand.CoreEntities;
using InbrandInterface;
using InbrandInterface.ServiceInterface;
using RepositoryLayer.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public DB context
        {
            get
            {
                return db as DB;
            }
        }
        public UserRepository(DB _db) : base(_db)
        {

        }
    }
}
