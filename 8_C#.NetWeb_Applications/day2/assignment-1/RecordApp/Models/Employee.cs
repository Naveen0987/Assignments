using System.ComponentModel.DataAnnotations;

namespace RecordApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Department { get; set; }

        [Required]
        public string? Designation { get; set; }

        [Required]
        public int Age { get; set; }

        // Constructor
        public Employee(string name, string department, string designation, int age)
        {
            Name = name;
            Department = department;
            Designation = designation;
            Age = age;
        }
    }
}