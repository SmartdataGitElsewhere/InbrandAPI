using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntityes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InbrandInterface.ServiceInterface
{
    public interface IIPAddressService
    {
        Task<APIResponse> GetIPAddressList();
        Task<APIResponse> AddNewIPAddress(IPAddressModel model);
        Task<APIResponse> EditIPAddress(IPAddressModel model);
        Task<APIResponse> DeleteIPAddress(int systemipid);
    }
}
