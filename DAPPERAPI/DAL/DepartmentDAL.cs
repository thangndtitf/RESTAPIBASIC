using System;
using Dapper;
using DAPPERAPI.ML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DAPPERAPI.DAL
{
	public class DepartmentDAL
	{
		private readonly IConfiguration _config;
		public DepartmentDAL(IConfiguration configuration)
		{
			this._config = configuration;
		}


		// Hàm lấy danh sách Department
        public  List<Department> getAllDepartment()
		{
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			List<Department> department = new List<Department>();

            try
			{
                connection.Open();
                department = (List<Department>)connection.Query<Department>("select * from MD_DEPARTMENTS");
                
            }catch(SqlException ex)
			{
				Console.Write(ex.ToString());
			}
			finally
			{
				connection.Close();
			}
            return department;
        }


		public Department getDepartmentByID (int departmentID)
		{
			Department department = new Department();
			using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			try
			{
				connection.Open();
				
				
				department = connection.QueryFirst<Department>("select * from MD_DEPARTMENTS dp " +
                    "where dp.DEPARTMENTID = @departmentID" , new { departmentID = departmentID});
				if(department == null)
				{
					Console.WriteLine("Department Null");
				}
            }
            catch(SqlException ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				connection.Close();
			}



			return department;
		}


    }
}

