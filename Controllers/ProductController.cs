using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
	public class ProductController : Controller
	{
		public ProductTable prodtbl = new ProductTable();

		[HttpPost]
		public ActionResult MyWorkPage(ProductTable products)
		{
			var result2 = prodtbl.insert_product(products);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult MyWorkPage()
		{
			return View(prodtbl);
		}
	}
}
