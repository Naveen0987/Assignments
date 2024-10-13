using System;
using System.Data.Linq;

namespace EmployeeCRUD
{
    public class EmployeeCRUD
    {
        private DataContext db;

        public EmployeeCRUD(DataContext db)
        {
            this.db = db;
        }

        public void ShowAllEmployees()
        {
            Table<Employee> employees = db.GetTable<Employee>();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name}, Gender: {employee.Gender}, Age: {employee.Age}, Salary: {employee.Salary}, DeptId: {employee.DeptId}");
            }
        }

        public void CreateEmployee()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Enter DeptId: ");
            int deptId = int.Parse(Console.ReadLine());

            Employee employee = new Employee
            {
                Name = name,
                Gender = gender,
                Age = age,
                Salary = salary,
                DeptId = deptId
            };

            db.GetTable<Employee>().InsertOnSubmit(employee);
            db.SubmitChanges();
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter updated Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter updated Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter updated Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter updated Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Enter updated DeptId: ");
            int deptId = int.Parse(Console.ReadLine());

            Employee employee = db.GetTable<Employee>().SingleOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.Name = name;
                employee.Gender = gender;
                employee.Age = age;
                employee.Salary = salary;
                employee.DeptId = deptId;
                db.SubmitChanges();
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee Id: ");
            int id = int.Parse(Console.ReadLine());

            Employee employee = db.GetTable<Employee>().SingleOrDefault(e => e.Id == id);
            if (employee != null)
            {
                db.GetTable<Employee>().DeleteOnSubmit(employee);
                db.SubmitChanges();
            }
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Show all employees");
                Console.WriteLine("2. Create employee");
                Console.WriteLine("3. Update employee");
                Console.WriteLine("4. Delete employee");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowAllEmployees();
                        break;
                    case 2:
                        CreateEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}