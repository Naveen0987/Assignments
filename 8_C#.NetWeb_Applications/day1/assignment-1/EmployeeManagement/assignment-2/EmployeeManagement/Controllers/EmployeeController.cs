using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // A list of sample employees
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, FirstName = "Naveen", MiddleName = "Ch", LastName = "", Salary = 50000, Email = "naveen@gmail.com", PhoneNumber = "8639868030", Address = "Nandyal", Country = "India", Age = 22, DateOfBirth = DateTime.Parse("2002-01-26") },
            new Employee { Id = 2, FirstName = "Charan", MiddleName = "", LastName = "k", Salary = 60000, Email = "charan@gmail.com", PhoneNumber = "987-654-3210", Address = "456 Elm St", Country = "Canada", Age = 28, DateOfBirth = DateTime.Parse("1996-02-02") },
            new Employee { Id = 3, FirstName = "Ravi", MiddleName = "Kumar", LastName = "S", Salary = 70000, Email = "ravi@gmail.com", PhoneNumber = "555-123-4567", Address = "789 Oak St", Country = "UK", Age = 35, DateOfBirth = DateTime.Parse("1989-03-03") },
            new Employee { Id = 4, FirstName = "Surya", MiddleName = "Yadav", LastName = "R", Salary = 80000, Email = "surya@gmail.com", PhoneNumber = "901-234-5678", Address = "321 Maple St", Country = "Australia", Age = 32, DateOfBirth = DateTime.Parse("1992-04-04") },
            new Employee { Id = 5, FirstName = "Mahesh", MiddleName = "", LastName = "M", Salary = 90000, Email = "mahesh@gmail.com", PhoneNumber = "111-222-3333", Address = "456 Pine St", Country = "Germany", Age = 40, DateOfBirth = DateTime.Parse("1984-05-05") },
        };

        // GET: Employee/Index
        public IActionResult Index()
        {
            return View(employees);
        }

        // GET: Employee/Details/{id}
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                // Generate the next employee ID
                newEmployee.Id = employees.Max(e => e.Id) + 1;
                employees.Add(newEmployee);

                return RedirectToAction("Index");
            }

            return View(newEmployee);
        }

        // GET: Employee/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Edit
        [HttpPost]
        public IActionResult Edit(Employee updatedEmployee)
        {
            if (ModelState.IsValid)
            {
                var employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
                if (employee != null)
                {
                    employee.FirstName = updatedEmployee.FirstName;
                    employee.MiddleName = updatedEmployee.MiddleName;
                    employee.LastName = updatedEmployee.LastName;
                    employee.Salary = updatedEmployee.Salary;
                    employee.Email = updatedEmployee.Email;
                    employee.PhoneNumber = updatedEmployee.PhoneNumber;
                    employee.Address = updatedEmployee.Address;
                    employee.Country = updatedEmployee.Country;
                    employee.Age = updatedEmployee.Age;
                    employee.DateOfBirth = updatedEmployee.DateOfBirth;

                    return RedirectToAction("Index");
                }
            }

            return View(updatedEmployee);
        }

        // GET: Employee/Delete/{id}
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }

            return RedirectToAction("Index");
        }
    }
}
