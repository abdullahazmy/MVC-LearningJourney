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
    }
}
