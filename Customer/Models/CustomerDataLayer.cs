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

        public Customer getCustomer(int id)
        {
            return this.dbContext.Customers.FirstOrDefault(e => e.CustomerID == id);
        }

        public void addCustomer(Customer customer)
        {
            if (customer.CustomerID == 0)
            {
                var customerCount = this.dbContext.Customers.Count();
                if (customerCount == 0)
                {
                    customer.CustomerID = 1;
                }
                else
                {
                    var custId = this.dbContext.Customers.Max(e => e.CustomerID);
                    customer.CustomerID = custId + 1;
                }
            }
            this.dbContext.Customers.Add(customer);
            this.dbContext.SaveChanges();
        }

        public void editCustomer(Customer customer)
        {
            this.dbContext.Customers.Update(customer);
            this.dbContext.SaveChanges();
        }

        public void deleteCustomer(int id)
        {
            var cust = this.dbContext.Customers.FirstOrDefault(e => e.CustomerID == id);
            this.dbContext.Customers.Remove(cust);
            this.dbContext.SaveChanges();
        }
    }
}
