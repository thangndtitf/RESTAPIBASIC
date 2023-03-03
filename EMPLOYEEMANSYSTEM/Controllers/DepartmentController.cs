using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMPLOYEEMANSYSTEM.ML;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMPLOYEEMANSYSTEM.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {

       private static List<Department> listDepartment = new List<Department>();


        [HttpGet]
        public IEnumerable<Department> getListDepartments()
        {
     
                return listDepartment;
            
        }


        [HttpPost]
        public IEnumerable<Department> insertNewDepartments([FromBody] Department dep)
        {
            if(dep == null)
            {
                return listDepartment;
            }

            else
            {
                listDepartment.Add(dep);
                return listDepartment;
            }
        }

    }
}

