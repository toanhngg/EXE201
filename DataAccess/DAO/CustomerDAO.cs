using BusinesObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    internal class CustomerDAO
    {
        private static CustomerDAO instance = null;
        public static readonly object instanceLock = new object();
        private static ShiawaseContext dbcontext = new ShiawaseContext();
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new CustomerDAO();
                }
                dbcontext = new ShiawaseContext();
                return instance;
            }
        }
        public IEnumerable<Customer> listCustomer()
        {
            var listCus = new List<Customer>();
            try
            {
                listCus = dbcontext.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCus;
        }
    }
}
