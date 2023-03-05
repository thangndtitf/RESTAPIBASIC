using System;
using EMPLOYEEMANSYSTEM.ML.ValidateML;

namespace EMPLOYEEMANSYSTEM.Validate
{
	public class StringValidateUtils
	{
		public StringValidateUtils()
		{
		}

        private StringValidateResult strValResult = new StringValidateResult();

		public StringValidateResult addStrValRs(Boolean isError, String message, String result )
		{
			try
			{
                strValResult.isError = isError;
                strValResult.message = message;
                strValResult.result = result;
            }
			catch (Exception ex)
			{
				Console.WriteLine("Lỗi ở phần lấy dữ liệu validate", ex.ToString());
			}
			return strValResult;
		}

    }
}

