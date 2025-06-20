using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

    }
}