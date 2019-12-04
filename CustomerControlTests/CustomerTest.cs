using CustomerPortal.Controllers;
using CustomerPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace CustomerControlTests
{
    public class CustomerTest
    {
        private DbContextOptions<MyDbContext> dbContext;
        public CustomerTest()
        {
            this.dbContext = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase(databaseName: "Customer").Options;
        }

        [Fact]
        public void TestAddCustomers()
        {
            //var cdl = new CustomerDataLayer((MyDbContext)dbContext);
            using (var context = new MyDbContext(dbContext))
            {
                var service = new CustomerDataLayer(context);

                Customer cust = new Customer();
                cust.CustomerID = 1;
                cust.FirstName = "Praj";
                cust.LastName = "Man";
                cust.DOB = DateTime.Now;

                int ret = service.addCustomer(cust);

                Assert.Equal(1, ret);
            }
        }

        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [Theory]
        public void TestEditCustomer(int id)
        {
            //var cdl = new CustomerDataLayer((MyDbContext)dbContext);
            using (var context = new MyDbContext(dbContext))
            {
                var service = new CustomerDataLayer(context);
                int response = 1;
                Customer cust = new Customer();
                cust.CustomerID = id;
                cust.FirstName = "Prajith";
                cust.LastName = "Maniyan";
                cust.DOB = DateTime.Now;

                Customer temp = service.getCustomer(id);
                if (temp == null)
                {
                    response = -1;
                }
                else
                {
                    response = 1;
                }

                int ret = service.editCustomer(cust);

                Assert.Equal(response, ret);
            }
        }

        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [Theory]
        public void TestDeleteCustomer(int id)
        {
            //var cdl = new CustomerDataLayer((MyDbContext)dbContext);
            using (var context = new MyDbContext(dbContext))
            {
                var service = new CustomerDataLayer(context);
                int response = 1;

                Customer temp = service.getCustomer(id);
                if (temp == null)
                {
                    response = -1;
                }
                else
                {
                    response = 1;
                }

                int ret = service.deleteCustomer(1);

                Assert.Equal(response, ret);
            }
        }

        [InlineData("abc")]
        [InlineData("def")]
        [InlineData("praj")]
        [InlineData("lop")]
        [Theory]
        public void TestSearchCustomer(string str)
        {
            //var cdl = new CustomerDataLayer((MyDbContext)dbContext);
            using (var context = new MyDbContext(dbContext))
            {
                var service = new CustomerDataLayer(context);

                Customer temp = service.searchCustomer(str);
                Customer ret = null;
                if (temp != null)
                {
                    ret = service.getCustomer(temp.CustomerID);
                }
                else
                {
                    ret = null;
                }

                Assert.Equal(temp, ret);
            }
        }
    }
}
