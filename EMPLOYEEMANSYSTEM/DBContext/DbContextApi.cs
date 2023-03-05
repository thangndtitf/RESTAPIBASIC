using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EMPLOYEEMANSYSTEM.DBContext
{
	public class DbContextApi
	{




        private static readonly string connectionString = "Data Source=localhost; Database=ElementMan; User Id=sa; Password=Anhyeuna2627@";

        public SqlConnection getSqlConn()
        {
            
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

        public bool connectionOpen(SqlConnection _con)
        {
            Boolean result = false;

            if(_con == null)
            {
                result = false;

            }else if(_con != null)
            {
                _con.Open();
                result = true;
            }
            return result;
        }

        public bool connectionClose(SqlConnection _con)
        {
            Boolean result = false;
            if (_con == null)
            {
                result = false;

            }
            else if (_con != null)
            {
                _con.Close();
                result = true;
            }


            return result;
        }



	}
}

