using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMPLOYEEMANSYSTEM.DAL;
using EMPLOYEEMANSYSTEM.ML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMPLOYEEMANSYSTEM.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IConfiguration configuration = new ConfigurationBuilder()
    .AddInMemoryCollection().Build();

        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        


        // GET: api/values
        [HttpGet]
        public Employee getEmployeeByID(int empID)
        {
            EmployeeDAL empDal = new EmployeeDAL(configuration);
            Employee emp = empDal.getEmployeeByID(empID);

            return emp;



        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

