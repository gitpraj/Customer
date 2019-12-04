using CustomerPortal.Models;
using Microsoft.EntityFrameworkCore;
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
            var cust = this.dbContext.Customers.AsNoTracking().FirstOrDefault(e => e.CustomerID == id);
            return cust;
        }

        public Customer searchCustomer(string str)
        {
            str = str.ToLower();
            var cust = this.dbContext.Customers.FirstOrDefault(e => e.FirstName.ToLower().Equals(str) || e.LastName.ToLower().Equals(str));
            return cust;
        }

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
