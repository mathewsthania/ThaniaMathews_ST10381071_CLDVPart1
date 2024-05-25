using KhumaloCraft.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
	public class ProductController : Controller
	{
		public ProductTable1 prodtbl = new ProductTable1();

		[HttpPost]
		public ActionResult MyWorkPage(ProductTable1 products)
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
