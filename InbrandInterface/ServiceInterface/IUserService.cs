using Inbrand.CoreEntities;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntityes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InbrandInterface.ServiceInterface
{
    public interface IUserService
    {
        Task<APIResponse> CreateUser(UserModel users);
        Task<APIResponse> GetUserList();
        Task<APIResponse> EditUserDetails(UserModel users);
        Task<APIResponse> ValidateUser(ValidateUserModel model);
        Task<APIResponse> DeleteUser(int userid);
        Task<APIResponse> ValidateIPAddress(string ipaddress);
    }
}
