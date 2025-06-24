using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context = new();

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            // Get All Employees
            return View(context.Employees.Include(e => e.Department).ToList());
        }

        public IActionResult Edit(int id)
        {
            // Get Employee by Id
            var employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View("Edit", employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee updatedEmployee)
        {
            var existingEmployee = context.Employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(updatedEmployee.Name))
                existingEmployee.Name = updatedEmployee.Name.Trim();

            if (!string.IsNullOrWhiteSpace(updatedEmployee.Position))
                existingEmployee.Position = updatedEmployee.Position.Trim();

            if (updatedEmployee.DepartmentId > 0)
                existingEmployee.DepartmentId = updatedEmployee.DepartmentId;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Delete Employee by Id
            var employee = context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            context.Employees.Remove(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}