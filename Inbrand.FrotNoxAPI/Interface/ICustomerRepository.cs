using Inbrand.CoreEntityes.FilterModelAndview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inbrand.FrotNoxAPI.Interface
{
    public interface ICustomerRepository
    {
        List<_Customer> All(string name);
    }
}
