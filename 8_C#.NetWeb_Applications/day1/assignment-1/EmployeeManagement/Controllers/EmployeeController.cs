using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, FirstName = "Naveen", MiddleName = "Ch", LastName = "", Salary = 50000, Email = "naveen@gmail.com", PhoneNumber = "8639868030", Address = "Nandyal", Country = "India", Age = 22, DateOfBirth = DateTime.Parse("2002-01-26") },
            new Employee { Id = 2, FirstName = "Charan", MiddleName = "", LastName = "k", Salary = 60000, Email = "charan@gmail.com", PhoneNumber = "987-654-3210", Address = "456 Elm St", Country = "Canada", Age = 28, DateOfBirth = DateTime.Parse("1996-02-02") },
            new Employee { Id = 3, FirstName = "Ravi", MiddleName = "Kumar", LastName = "S", Salary = 70000, Email = "ravi@gmail.com", PhoneNumber = "555-123-4567", Address = "789 Oak St", Country = "UK", Age = 35, DateOfBirth = DateTime.Parse("1989-03-03") },
            new Employee { Id = 4, FirstName = "Surya", MiddleName = "Yadav", LastName = "R", Salary = 80000, Email = "surya@gmail.com", PhoneNumber = "901-234-5678", Address = "321 Maple St", Country = "Australia", Age = 32, DateOfBirth = DateTime.Parse("1992-04-04") },
            new Employee { Id = 5, FirstName = "Mahesh", MiddleName = "", LastName = "M", Salary = 90000, Email = "mahesh@gmail.com", PhoneNumber = "111-222-3333", Address = "456 Pine St", Country = "Germany", Age = 40, DateOfBirth = DateTime.Parse("1984-05-05") },
        };

        // GET: Employee
        public IActionResult Index()
        {
            return View(employees);
        }
    }
}