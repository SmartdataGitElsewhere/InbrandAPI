using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbrand.CoreEntityes.APIResponses
{
    public class APIResponse
    {
        public APIResponse()
        {
            data = new data();
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public data data { get; set; }
        public bool Isadmin { get; set; }
    }

    public class data
    {
        public User Userdetails { get; set; }
        public List<UserModel> UsersList { get; set; }
        public List<SubscriptionsModel> SubscriptionsModelList { get; set; }
        public List<IPAddressModel> IPAddressModellist { get; set; }
    }
}
