using System.Diagnostics;
using KhumaloCraft.Models;
using KhumaloCraftEmporium.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraftEmporium.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ContactUs()
		{
			return View();
		}

		public IActionResult AboutUs()
		{
			return View();
		}

        public IActionResult MyWorkPage()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult Logout()
        {
			return View("Index");
        }

        public IActionResult MyWorkPageShopping()
        {
            var products = ProductTable1.GetAllProducts();
            return View(products);
        }

        public IActionResult Cart()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
