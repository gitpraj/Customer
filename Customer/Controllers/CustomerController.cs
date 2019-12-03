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
        public CustomerController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.dbContext.Customers.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(this.dbContext.Customers.FirstOrDefault(e => e.Id == id));
        }

        // POST api/customer
        [HttpPost]
        public IActionResult Post([FromBody]Customer product)
        {
            this.dbContext.Customers.Add(product);
            this.dbContext.SaveChanges();
            return Created("Get", product);
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer product)
        {

        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
