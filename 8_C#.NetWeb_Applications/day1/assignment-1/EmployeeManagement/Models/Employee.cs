namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public decimal Salary { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string Country { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {MiddleName} {LastName}";
    }
}