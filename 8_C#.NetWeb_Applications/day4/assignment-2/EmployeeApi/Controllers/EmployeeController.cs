using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Naveen", LastName = "Ch", Country = "India", Gender = "Male", PhoneNumber = "8639868030", DateOfBirth = new DateTime(2002, 1, 26), Age = 22 },
            // Add more predefined employees if necessary
        };

        [HttpGet("list")]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        [HttpGet("details/{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee newEmployee)
        {
            newEmployee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
        }

        [HttpPut("details/{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();

            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Country = updatedEmployee.Country;
            employee.Gender = updatedEmployee.Gender;
            employee.PhoneNumber = updatedEmployee.PhoneNumber;
            employee.DateOfBirth = updatedEmployee.DateOfBirth;
            employee.Age = updatedEmployee.Age;

            return Ok(employee);
        }

        [HttpDelete("details/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            employees.Remove(employee);
            return NoContent();
        }
    }
}
