using FortnoxAPILibrary;
using FortnoxAPILibrary.Connectors;
using Inbrand.CoreEntityes.FilterModelAndview;
using Inbrand.FrotNoxAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbrand.FrotNoxAPI
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<_Customer> All(string name)
        {
            var _customerConnector = new CustomerConnector();
            return ConvertToCustomerView(_customerConnector.Find().CustomerSubset, name);
        }

        private List<_Customer> ConvertToCustomerView(List<CustomerSubset> customers, string name)
        {
            List<_Customer> lst = new List<_Customer>();
            if (name != null)
            {
                customers = customers.Where(x => x.Name.ToUpper().Contains(name.ToUpper())).ToList();
            }
            foreach (var item in customers)
            {
                lst.Add(new _Customer()
                {
                    Address1 = item.Address1,
                    Address2 = item.Address2,
                    City = item.City,
                    CustomerNumber = item.CustomerNumber,
                    Email = item.Email,
                    Name = item.Name,
                    OrganisationNumber = item.OrganisationNumber,
                    Phone = item.Phone,
                    ZipCode = item.ZipCode,
                    url = item.url
                });
            }
            return lst;
        }
    }
}
