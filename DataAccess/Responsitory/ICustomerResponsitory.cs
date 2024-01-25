using BusinesObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Responsitory
{
    public interface ICustomerResponsitory
    {
        IEnumerable<Customer> GetCustomer();
    }
}
