using InbrandInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inbrand.CoreEntities;
using InbrandInterface;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.Common.Helpers;
using Inbrand.CoreEntityes.Models;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitofwork)
        {
            this._unitOfWork = unitofwork;
        }
        public async Task<APIResponse> CreateUser(UserModel model)
        {
            APIResponse response = new APIResponse();
            try
            {
                User user = new User();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Password = model.Password;
                user.Status = true;
                user.AspNetUserId = model.AspNetUserId;
                _unitOfWork.Users.Add(user);
                await _unitOfWork.SaveChangesAsync();
                response.StatusCode = StaticResource.successStatusCode;
                response.Message = StaticResource.successmessage;
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> GetUserList()
        {
            APIResponse response = new APIResponse();
            try
            {
                var userlist = await _unitOfWork.Users.FindAllAsync(x => x.Status);
                var list = userlist.Select(x => new UserModel
                {
                    UserId = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Password = x.Password,
                    ConfirmPassword = x.Password,
                    Status = x.Status == true ? "Active" : "InActive",
                    AspNetUserId = x.AspNetUserId
                }).ToList();
                response.data.UsersList = list;
                response.StatusCode = StaticResource.successStatusCode;
                response.Message = StaticResource.successmessage;
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> EditUserDetails(UserModel users)
        {
            APIResponse response = new APIResponse();
            try
            {
                var isexist = await _unitOfWork.Users.FindAsync(x => x.UserId == users.UserId);
                if (isexist != null)
                {
                    isexist.FirstName = users.FirstName;
                    isexist.LastName = users.LastName;
                    isexist.PhoneNumber = users.PhoneNumber;
                    isexist.Password = users.Password;
                    _unitOfWork.Users.Update(isexist);
                    await _unitOfWork.SaveChangesAsync();
                    response.StatusCode = StaticResource.successStatusCode;
                    response.Message = StaticResource.successmessage;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> DeleteUser(int userid)
        {
            APIResponse response = new APIResponse();
            try
            {
                var existuser = await _unitOfWork.Users.FindAsync(x => x.UserId == userid);
                if (existuser != null)
                {
                    existuser.Status = false;
                    _unitOfWork.Users.Update(existuser);
                    await _unitOfWork.SaveChangesAsync();
                    response.StatusCode = StaticResource.successStatusCode;
                    response.Message = StaticResource.successmessage;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> ValidateUser(ValidateUserModel model)
        {
            APIResponse response = new APIResponse();
            try
            {
                var isexistrecord = await _unitOfWork.Users.FindAsync(x => x.UserName == model.UserName && x.Status == true);
                if (isexistrecord != null)
                {
                    //if (!model.isadminrole)
                    //{
                    //    var checkip = await _unitOfWork.IPAddress.FindAsync(x => x.IPAddress == model.IPAddress && x.isdeleted == false);
                    //    if (checkip != null)
                    //    {
                    //        response.StatusCode = StaticResource.successStatusCode;
                    //        response.Message = StaticResource.successmessage;
                    //    }
                    //    else
                    //    {
                    //        response.StatusCode = StaticResource.failStatusCode;
                    //        response.Message = "Invalid User";
                    //    }
                    //}
                    //else
                    //{
                    //    response.StatusCode = StaticResource.successStatusCode;
                    //    response.Message = StaticResource.successmessage;
                    //    response.Isadmin = model.isadminrole;
                    //}
                    response.StatusCode = StaticResource.successStatusCode;
                    response.Message = StaticResource.successmessage;
                    response.Isadmin = model.isadminrole;
                }
                else
                {
                    response.StatusCode = StaticResource.failStatusCode;
                    response.Message = "Invalid User";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> ValidateIPAddress(string ipaddress)
        {
            APIResponse response = new APIResponse();
            try
            {
                var checkip = await _unitOfWork.IPAddress.FindAsync(x => x.IPAddress == ipaddress && x.isdeleted == false);
                if (checkip != null)
                {
                    response.StatusCode = StaticResource.successStatusCode;
                    response.Message = StaticResource.successmessage;
                }
                else
                {
                    response.StatusCode = StaticResource.failStatusCode;
                    response.Message = "Invalid User";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.failStatusCode;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
