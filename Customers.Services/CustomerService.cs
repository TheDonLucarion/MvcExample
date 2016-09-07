using Customers.Models;
using Customers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customers.Services
{
    public class CustomerService
    {
        private CustomerService sc = new CustomerService();

        public IEnumerable<CustomerList> GetList()
        {
            using (var ctx = new CustomerDbContext())
            {
                return
                ctx
                .CustomerList
                .Where(e => e.Id == e.Id)
                .Select(
                    e =>
                    new CustomerList
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName
                    })
                    .ToArray();
            }
        }


        public bool CreateCustomer (CustomerList vm)
        {
            using (var ctx = new CustomerDbContext())
            {
                var entity =
                    new CustomerList
                    {
                        Id = vm.Id,
                        FirstName = vm.FirstName,
                        LastName = vm.LastName
                    };
                ctx.CustomerList.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }





    }
}