using System;
using Dapper;
using DAPPERAPI.ML;
using Microsoft.Data.SqlClient;

namespace DAPPERAPI.DAL
{
	public class ElementDAL
	{
        private readonly IConfiguration _config;

        public ElementDAL(IConfiguration config)
        {
            _config = config;
        }

        public List<Element> getAllElement()
		{
			List<Element> result = new List<Element>();
			var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			try
			{
				string storeProcedure = "exec ELEMENT_GETALL";
				connection.Open();
				result = (List<Element>)connection.Query<Element>(storeProcedure);
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


		public Element getElementByID(int elementID)
		{
			Element element = new Element();
            var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
			try
			{
				string queryStore = "exec ELEMENT_GETBYID @ELEMENTID";

                connection.Open();
				var value = new { ELEMENTID = elementID};

				if ((Element)connection.QueryFirstOrDefault<Element>(queryStore, value) != null)
				{
                    element = (Element)connection.QueryFirstOrDefault<Element>(queryStore, value);
                }
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.ToString());
			}
			finally
			{
				connection.Close();
			}



            return element;
		}

	}
}

