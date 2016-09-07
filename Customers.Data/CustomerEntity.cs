using Customers.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customers.Data
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class CustomerDbContext : DbContext {

        public CustomerDbContext()
            {
            
            }
        public static CustomerDbContext Create()
        {
            return new CustomerDbContext();
        }

        public DbSet<CustomerList> CustomerList { get; set; }
    }
}