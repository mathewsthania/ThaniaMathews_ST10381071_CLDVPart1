using System.Diagnostics;
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

		public IActionResult About_Us()
		{
			return View();
		}

        public IActionResult MyWorkPage()
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
