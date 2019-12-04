using CustomerPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPortal.Models
{
    /* Data Layer for the Customer Portal */
    public class CustomerDataLayer
    {
        private MyDbContext dbContext;
        public CustomerDataLayer(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /* getCustomers() - get all customers from the db */
        public List<Customer> getCustomers()
        {
            return this.dbContext.Customers.ToList();
        }

        /* getCustomer() - get a customer with the help of the customerId from the db */
        public Customer getCustomer(int id)
        {
            var cust = this.dbContext.Customers.AsNoTracking().FirstOrDefault(e => e.CustomerID == id);
            return cust;
        }

        /* searchCustomer() - partial search for customer, 
         * matches the specified string against firstName or LastName. */
        public Customer searchCustomer(string str)
        {
            str = str.ToLower();
            var cust = this.dbContext.Customers.FirstOrDefault(e => e.FirstName.ToLower().Equals(str) || e.LastName.ToLower().Equals(str));
            return cust;
        }

        /* addCustomer() - add a new customer. CustomerId integer to be greater than
         * zero. If the request contains customerId as 0, set it to 1 + the max customerId from the db  */
        public int addCustomer(Customer customer)
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

                this.dbContext.Customers.Add(customer);
                this.dbContext.SaveChanges();
                return 1;
            } else
            {
                Customer cust = this.dbContext.Customers.Find(customer.CustomerID);
                if (cust == null)
                {
                    this.dbContext.Customers.Add(customer);
                    this.dbContext.SaveChanges();
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /* editCustomer() - customer data updated */
        public int editCustomer(Customer customer)
        {
            if (customer != null)
            {
                int cust = this.dbContext.Customers.AsNoTracking().Count(x => x.CustomerID == customer.CustomerID);
                if (cust > 0)
                {
                    this.dbContext.Customers.Update(customer);
                    this.dbContext.SaveChanges();
                    return 1;
                } else
                {
                    return -1;
                }
            } else
            {
                return -1;
            }
        }

        /* deleteCustomer() - delete customers from the db */
        public int deleteCustomer(int id)
        {
            var customerCount = this.dbContext.Customers.Count();
            if (customerCount == 0)
            {
                return -1;
            }
            else
            {
                var cust = this.dbContext.Customers.FirstOrDefault(e => e.CustomerID == id);
                if (cust != null)
                {
                    this.dbContext.Customers.Remove(cust);
                    this.dbContext.SaveChanges();
                    return 1;
                } else
                {
                    return -1;
                }
            }          
        }
    }
}
