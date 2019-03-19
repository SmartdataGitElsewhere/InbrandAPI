using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.FrotNoxAPI.Interface;
using InbrandInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository _customerRepository)
        {
            this.customerRepository = _customerRepository;
        }
        public List<_Customer> All(string name)
        {
            return customerRepository.All(name);
        }
    }
}
