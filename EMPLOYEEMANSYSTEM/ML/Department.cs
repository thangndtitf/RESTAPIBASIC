using System;
namespace EMPLOYEEMANSYSTEM.ML
{
	public class Department
	{

		public int departmentID { get; set; }
		public string departmentName { get; set; }
		public int departmentMaxNumEmp { get; set; }
		public DateTime createdDate { get; set; }
		public bool isdeleted { get; set; }
		public bool isActive { get; set; }

        public Department(int departmentID, string departmentName, int departmentMaxNumEmp, DateTime createdDate, bool isdeleted, bool isActive)
        {
            this.departmentID = departmentID;
            this.departmentName = departmentName ?? throw new ArgumentNullException(nameof(departmentName));
            this.departmentMaxNumEmp = departmentMaxNumEmp;
            this.createdDate = createdDate;
            this.isdeleted = isdeleted;
            this.isActive = isActive;
        }
        public Department() {}
     
    

            
    }
}

