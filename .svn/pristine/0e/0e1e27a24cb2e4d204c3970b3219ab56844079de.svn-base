using Inbrand.CoreEntityes;
using InbrandInterface;
using RepositoryLayer.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class IPAddressRepository : Repository<StoreSystemIP>, IIPAddressRepository
    {
        public DB context
        {
            get
            {
                return db as DB;
            }
        }
        public IPAddressRepository(DB _db) : base(_db)
        {

        }
    }
}
