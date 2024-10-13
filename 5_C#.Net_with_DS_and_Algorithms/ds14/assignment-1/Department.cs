using System.Data.Linq.Mapping;

namespace EmployeeCRUD
{
    [Table(Name = "Department")]
    public class Department
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
    }
}