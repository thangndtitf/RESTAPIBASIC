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


		// Lấy department theo ID 
		public Department getDepartmentByID (int departmentID)
		{
			Department department = new Department();
			using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			try
			{
				connection.Open();

				String queryStr = "exec DEPARTMENT_SEARCHID @DEPID";
				var value = new { DEPID = departmentID };
				department = connection.QueryFirst<Department>(queryStr, value);

                //department = connection.QueryFirst<Department>("select * from MD_DEPARTMENTS dp " +
                //    "where dp.DEPARTMENTID = @departmentID" , new { departmentID = departmentID});
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

		//Insert mới 1 department 
		public Boolean insertNewDepartment(Department newDepartment)
		{
			using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			Boolean result = false;
			try
			{
				connection.Open();
				var sqlStr = "exec DEPARTMENT_ADD @NAME , @DESCRIPTION";
				var value = new { NAME = newDepartment.departmentName,
					DESCRIPTION = newDepartment.description };
               connection.Query<Department>(sqlStr,value);
				result = true;
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				connection.Close();
			}
			return result;

		}


	}
}

