using EMPLOYEEMANSYSTEM.ML;
using Microsoft.AspNetCore.Mvc;

namespace EMPLOYEEMANSYSTEM.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>()
    {
        new Employee(){employeeID= 1, employeeName = "Nguyễn Đinh Tất Thắng", DOB = DateTime.Now, employeeNum= 162880},
        new Employee(){employeeID= 2, employeeName = "Trần NGuyễn Thảo Khanh", DOB = DateTime.Now, employeeNum= 162881},

    };

    [HttpGet]
    public IEnumerable<Employee> getEmployee()
    {
        return employees;
    }

    [HttpPost]
    public IEnumerable<Employee> addEmployee([FromBody] Employee emp)
    {
        employees.Add(emp);
        return employees;
    }

    [HttpPut("{id}")]
    public IEnumerable<Employee> updateEmployee(int id, [FromBody] Employee emp)
    {
        employees[id] = emp;
        return employees;
    }

}

