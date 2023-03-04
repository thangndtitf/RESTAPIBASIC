using System;
using EMPLOYEEMANSYSTEM.DBContext;
using EMPLOYEEMANSYSTEM.ML;
using Microsoft.Data.SqlClient;

namespace EMPLOYEEMANSYSTEM.DAL
{
	public class EmployeeDAL
	{
        private IConfiguration configuration = new ConfigurationBuilder()
   .AddInMemoryCollection().Build();

        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Employee getEmployeeByID (int employeeID)
        {
            Employee emp = new Employee();
            DbContextApi dbApi = new DbContextApi(configuration);

            try
            {
                SqlConnection _conn = dbApi.getSqlConn();
                dbApi.connectionOpen(_conn);
                SqlCommand _cmd = new SqlCommand("select el.ELEMENTID , el.ELEMENTNAME , el.DOB , el.ELEMENTUSERNUMBER  " +
                "from MD_ELEMENTS el\nwhere el.ELEMENTID = 4", _conn);
                //_cmd.Parameters.AddWithValue("@elId", employeeID);
                SqlDataReader reader = _cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        emp.employeeID = reader.GetInt32(0);
                        emp.employeeName = reader.GetString(1);
                        emp.DOB = reader.GetDateTime(2);
                        emp.employeeNum = reader.GetInt32(3);
                    }
                }
                else
                {
                    emp = null;
                }
                dbApi.connectionClose(_conn);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error at Employee DAL ", ex.ToString());

            }
            finally
            {
               
            }



            return emp;
        }
    }
}

