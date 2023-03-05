using System;
using EMPLOYEEMANSYSTEM.ML.ValidateML;

namespace EMPLOYEEMANSYSTEM.Validate
{
	public class StringValidate
	{

		private StringValidateResult strValRe = new StringValidateResult();
		public StringValidateResult validateNameUser(String userName)
		{
			
			if(userName == null)
			{
				strValRe.isError = true;
				strValRe.message = "Lỗi chuỗi ký tự không có dữ liệu, Null";
				strValRe.result = userName;
			}else if(userName.Trim() == null)
			{
                strValRe.isError = true;
                strValRe.message = "Lỗi chuỗi ký tự không có dữ liệu. Vui lòng không nhập space";
                strValRe.result = userName;
            }else if(userName.Length <= -1)
			{
                strValRe.isError = true;
                strValRe.message = "Lỗi độ dài chuỗi ký tự không hợp lệ";
                strValRe.result = userName;
			}
			else
			{
                strValRe.isError = false;
                strValRe.message = "Thành công";
                strValRe.result = userName;
            }
			return strValRe;
		}
	}
}

