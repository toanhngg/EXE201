﻿using BusinesObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Responsitory
{
    internal class CustomerResponsitory : ICustomerResponsitory
    {
        public IEnumerable<Customer> GetCustomer() => CustomerDAO.Instance.listCustomer();

    }
}
