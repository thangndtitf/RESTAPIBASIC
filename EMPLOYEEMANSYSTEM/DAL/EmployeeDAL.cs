using System;
using EMPLOYEEMANSYSTEM.DBContext;
using EMPLOYEEMANSYSTEM.ML;
using EMPLOYEEMANSYSTEM.Validate;
using Microsoft.Data.SqlClient;

namespace EMPLOYEEMANSYSTEM.DAL
{
	public class EmployeeDAL
	{


        //public EmployeeDAL(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        private StringValidate strVal = new StringValidate();

        public Employee getEmployeeByID (int employeeID)
        {
            Employee emp = new Employee();
            DbContextApi dbApi = new DbContextApi();
            SqlConnection _conn = dbApi.getSqlConn();
            
            try
            {
                
                _conn.Open();
                //dbApi.connectionOpen(_conn);
                SqlCommand _cmd = new SqlCommand("select el.ELEMENTID ,el.ELEMENTNAME ,el.DOB ,el.ELEMENTUSERNUMBER  " +
                "from MD_ELEMENTS el\n where el.ELEMENTID = @elId", _conn);
                _cmd.Parameters.AddWithValue("@elId", employeeID);
                SqlDataReader reader = _cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Int32 empID = reader.GetInt32(0);
                        String empName = reader.GetString(1);
                        DateTime empDOB = reader.GetDateTime(2);
                        Int32 empNum = reader.GetInt32(3);

                        if (strVal.validateNameUser(empName).isError == true)
                        {
                            break;
                            Console.WriteLine(strVal.ToString());
                        }

                        emp.employeeID = empID;
                        emp.employeeName = empName;
                        emp.DOB = empDOB;
                        emp.employeeNum = empNum;
                    }
                }
                else
                {
                    emp = null;
                }
                //dbApi.connectionClose(_conn);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error at Employee DAL ", ex.ToString());

            }
            finally
            {
                _conn.Close();
            }



            return emp;
        }
    }
}

