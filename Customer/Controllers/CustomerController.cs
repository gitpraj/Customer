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
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound("Customer was not found");
                }
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
        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            try
            {
                int ret = custDataLayer.editCustomer(customer);
                if (ret != -1)
                {
                    return Created("Get", customer);
                } else
                {
                    return NotFound("Customer was not found");
                }
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
                int ret = custDataLayer.deleteCustomer(id);
                if (ret != 1)
                {
                    return NotFound("Customer id: " + id + " was not found");
                }
                else
                {
                    return Ok(this.dbContext.Customers.ToList());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Search/{str}")]
        public IActionResult Search(string str)
        {
            try
            {
                var customer = custDataLayer.searchCustomer(str);
                if (customer != null)
                {
                    return Ok(customer);
                }
                else
                {
                    return NotFound("Customer with firstname or lastname as " + str + " was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
