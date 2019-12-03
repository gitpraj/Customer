using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private MyDbContext dbContext;
        private CustomerDataLayer custDataLayer;
        public CustomerController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
            custDataLayer = new CustomerDataLayer(dbContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = custDataLayer.getCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(this.dbContext.Customers.FirstOrDefault(e => e.CustomerID == id));
        }

        // POST api/customer
        [HttpPost]
        public IActionResult Post([FromBody]Customer product)
        {
            if (product.CustomerID == 0)
            {
                var customerCount = this.dbContext.Customers.Count();
                if (customerCount == 0)
                {
                    product.CustomerID = 1;
                } else
                {
                    var custId = this.dbContext.Customers.Max(e => e.CustomerID);
                    product.CustomerID = custId + 1;
                }
            }
            this.dbContext.Customers.Add(product);
            this.dbContext.SaveChanges();
            return Created("Get", product);
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer product)
        {
            this.dbContext.Customers.Update(product);
            this.dbContext.SaveChanges();
            return Created("Get", product);
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cust = this.dbContext.Customers.FirstOrDefault(e => e.CustomerID == id);
            this.dbContext.Customers.Remove(cust);
            this.dbContext.SaveChanges();
            return Ok(this.dbContext.Customers.ToList());
        }
    }
}
