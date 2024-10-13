using System.Data.Linq.Mapping;

namespace EmployeeCRUD
{
    [Table(Name = "Employee")]
    public class Employee
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Gender { get; set; }
        [Column]
        public int Age { get; set; }
        [Column]
        public decimal Salary { get; set; }
        [Column]
        public int DeptId { get; set; }
    }
}