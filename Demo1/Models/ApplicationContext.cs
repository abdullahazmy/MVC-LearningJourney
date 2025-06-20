using Microsoft.EntityFrameworkCore;

namespace Demo1.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public ApplicationContext()
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);


            // Departments with Location
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT", Location = "Building A" },
                new Department { Id = 2, Name = "HR", Location = "Building B" },
                new Department { Id = 3, Name = "Finance", Location = "Building C" }
            );

            // Employees with Position and ImageUrl
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Abdullah",
                    Position = "Software Engineer",
                    Salary = 10000,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2,
                    Name = "Mona",
                    Position = "HR Manager",
                    Salary = 8000,
                    DepartmentId = 2
                },
                new Employee
                {
                    Id = 3,
                    Name = "Ali",
                    Position = "DevOps Engineer",
                    Salary = 9000,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 4,
                    Name = "Sara",
                    Position = "Accountant",
                    Salary = 9500,
                    DepartmentId = 3
                }
            );
        }
    }
}
