using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json; // Add this for logging

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Naveen", MiddleName = "", LastName = "Ch", Country = "India", Gender = "Male", PhoneNumber = "8639868030", DateOfBirth = new DateTime(2002, 1, 26), Age = 22 },
            new Employee { Id = 2, FirstName = "Charan", MiddleName = "", LastName = "K", Country = "Canada", Gender = "Male", PhoneNumber = "0987654321", DateOfBirth = new DateTime(2001, 2, 2), Age = 23 },
            new Employee { Id = 3, FirstName = "Surya", MiddleName = "", LastName = "R", Country = "India", Gender = "Male", PhoneNumber = "9984521385", DateOfBirth = new DateTime(2002, 2, 26), Age = 22 },
            new Employee { Id = 4, FirstName = "Charan", MiddleName = "", LastName = "K", Country = "USA", Gender = "Male", PhoneNumber = "0987654321", DateOfBirth = new DateTime(2000, 2, 2), Age = 24 },
            new Employee { Id = 5, FirstName = "Pavan", MiddleName = "", LastName = "S", Country = "UK", Gender = "Male", PhoneNumber = "007654321", DateOfBirth = new DateTime(2002, 2, 2), Age = 22 }
        };

        // (a) Get the list of employees
        [HttpGet("list")]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        // (b) Get a single employee by ID
        [HttpGet("details/{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound(); // Returns 404 if not found
            }
            return Ok(employee);
        }

        // (c) Create a new employee
        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee newEmployee) // Ensure data comes from the body
        {
            // Log to console for debugging
            Console.WriteLine("Creating employee: " + JsonConvert.SerializeObject(newEmployee));
            
            newEmployee.Id = employees.Max(e => e.Id) + 1; // Set new ID
            employees.Add(newEmployee); // Add to the list
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee); // Returns 201 Created
        }
    }
}
