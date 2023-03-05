using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMPLOYEEMANSYSTEM.BL;
using EMPLOYEEMANSYSTEM.DAL;
using EMPLOYEEMANSYSTEM.ML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMPLOYEEMANSYSTEM.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public Employee getEmployeeByID([FromBody]int empID)
        {
            EmployeeBL empBl = new EmployeeBL();
            Employee emp = empBl.getEmployeeByID(empID);

            return emp;
         }

        
    }
}

