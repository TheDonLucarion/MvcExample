using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customers.Models
{
    public class CustomerEditModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}