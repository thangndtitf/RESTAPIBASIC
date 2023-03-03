using EMPLOYEEMANSYSTEM.ML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
    
    private readonly IConfiguration configuration = new ConfigurationBuilder()
    .AddInMemoryCollection().Build() ;

    public WeatherForecastController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    [HttpGet]
    public int Index()
    {
        string connectionString = configuration.GetConnectionString("DefaultConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("select * from MD_ELEMENTS", connection);
        
        

        return 1;
    }


    //[HttpGet]
    //public IEnumerable<Employee> getEmployee()
    //{
    //    return employees;
    //}

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

