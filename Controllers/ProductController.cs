using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult MyWorkPageShopping()
        {
            var products = ProductTable1.GetAllProducts();

            Console.WriteLine("Products in MyWorkPageShopping: " + products.Count);

            return View(products);
        }
    }
}