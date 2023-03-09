using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAPPERAPI.DAL;
using DAPPERAPI.ML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DAPPERAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _config;
        public DepartmentController(IConfiguration config)
        {
            this._config = config;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Department>>> getAllDepartment()
        //{
        //    using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        //    var department = await connection.QueryAsync<Department>("select * from MD_DEPARTMENTS");
        //    return Ok(department);
        //}
        //[HttpGet]
        //public  List<Department> getAllsDepartment()
        //{
        //    DepartmentDAL departmentDAL = new DepartmentDAL(_config);
        //    return departmentDAL.getAllDepartment();
        //}



        [HttpGet]
        public Department getDepartmentByID([FromBody] int departmentID)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL(_config);
            if(departmentDAL.getDepartmentByID(departmentID) == null)
            {
                return null;
            }
            else
            {
                return departmentDAL.getDepartmentByID(departmentID);
            }
            

        }

    }
}

