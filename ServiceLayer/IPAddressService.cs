using Inbrand.Common.Helpers;
using Inbrand.CoreEntityes;
using Inbrand.CoreEntityes.APIResponses;
using Inbrand.CoreEntityes.Models;
using InbrandInterface;
using InbrandInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class IPAddressService : IIPAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IPAddressService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<APIResponse> GetIPAddressList()
        {
            APIResponse response = new APIResponse();
            try
            {
                var ipaddresslist = await _unitOfWork.IPAddress.FindAllAsync(x => x.isdeleted == false);
                var list = ipaddresslist.Select(x => new IPAddressModel
                {
                    SystemIPId = x.SystemIPId,
                    IPAddress = x.IPAddress
                }).ToList();
                response.data.IPAddressModellist = list;
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

        public async Task<APIResponse> AddNewIPAddress(IPAddressModel model)
        {
            APIResponse response = new APIResponse();
            try
            {
                StoreSystemIP obj = new StoreSystemIP();
                obj.IPAddress = model.IPAddress;
                obj.isdeleted = false;
                 _unitOfWork.IPAddress.Add(obj);
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

        public async Task<APIResponse> EditIPAddress(IPAddressModel model)
        {
            APIResponse response = new APIResponse();
            try
            {
                var isexist = await _unitOfWork.IPAddress.FindAsync(x => x.SystemIPId == model.SystemIPId);
                if (isexist != null)
                {
                    isexist.IPAddress = model.IPAddress;
                    _unitOfWork.IPAddress.Update(isexist);
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

        public async Task<APIResponse> DeleteIPAddress(int systemipid)
        {
            APIResponse response = new APIResponse();
            try
            {
                var isexist = await _unitOfWork.IPAddress.FindAsync(x => x.SystemIPId == systemipid);
                if (isexist != null)
                {
                    isexist.isdeleted = true;
                    _unitOfWork.IPAddress.Update(isexist);
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
    }
}
