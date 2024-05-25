using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
	public class ProductDisplayController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			var products = ProductDisplayModel.SelectProducts();
			return View(products);
		}
	}
}
