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
            try
            {
                var customers = custDataLayer.getCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = custDataLayer.getCustomer(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/customer
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            try
            {
                custDataLayer.addCustomer(customer);
                return Created("Get", customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Customer customer)
        {
            try
            {
                custDataLayer.editCustomer(customer);
                return Created("Get", customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                custDataLayer.deleteCustomer(id);
                return Ok(this.dbContext.Customers.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
