using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers.Productos
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var productSample = new Models.Products.ProductSample();
            var products = productSample.GetProducts();
            return View("ViewProducts", products);
        }

        public IActionResult Details(int id)
        {
            var productSample = new Models.Products.ProductSample();
            var product = productSample.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("ViewProductDetails", product);
        }
    }
}
