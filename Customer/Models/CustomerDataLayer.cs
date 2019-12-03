using CustomerPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Models
{
    public class CustomerDataLayer
    {
        private MyDbContext dbContext;
        public CustomerDataLayer(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Customer> getCustomers()
        {
            return this.dbContext.Customers.ToList();
        }
    }
}
