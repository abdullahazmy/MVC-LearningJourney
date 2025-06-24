using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationContext context = new ApplicationContext();

        public DepartmentController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            // Get All Departments  
            List<Department> departments = context.Departments.Include(e => e.Employees).ToList();
            return View("Index", departments);
        }

        public IActionResult New()
        {
            // Show New Department Form  
            return View("New", new Department());
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (department.Name == null || department.Location == null)
            {
                ModelState.AddModelError("", "Name and Location are required.");
                return View("New", department);
            }
            // Add New Department  
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
