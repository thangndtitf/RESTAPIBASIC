using System;
namespace EMPLOYEEMANSYSTEM.ML
{
	public class Employee
	{
		public int employeeID { get; set; }
		public String employeeName { get; set; }
		public DateTime DOB { get; set; }
		public int employeeNum { get; set; }

        public Employee(int employeeID, string employeeName, DateTime dob, int employeeNum)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName ?? throw new ArgumentNullException(nameof(employeeName));
            DOB = dob;
            this.employeeNum = employeeNum;
        }

        public Employee()
        {
        }
    }
}

