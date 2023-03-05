using System;
using EMPLOYEEMANSYSTEM.DAL;
using EMPLOYEEMANSYSTEM.ML;

namespace EMPLOYEEMANSYSTEM.BL
{
	public class EmployeeBL
	{


        public Employee getEmployeeByID(int empID)
        {
            EmployeeDAL empDal = new EmployeeDAL();
            Employee emp = empDal.getEmployeeByID(empID);
            if(emp.employeeID == null || emp.employeeID == -1)
            {
                emp = null;
            }
            return emp;
        }

    }
}

