using System.Security.Claims;
using KhumaloCraft.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraft.Controllers
{
	[Authorize]
	public class ProductDisplayController : Controller
	{
		private readonly Cart _cart;

		public ProductDisplayController()
		{
			_cart = new Cart();
		}

		[HttpGet]
		public IActionResult Index()
		{
			var products = ProductDisplayModel.SelectProducts();
			return View(products);
		}


		[HttpPost]
		public IActionResult PlaceOrder()
		{
			var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (int.TryParse(UserID, out int UserIDValue))
			{
				foreach (var item in _cart.Items)
				{
					TransactionTable2.InsertOrder(UserIDValue, item.ProductID);
				}

				_cart.Clear();
				return RedirectToAction("OrderConfirmation");
			}
			else
			{
				return RedirectToAction("Login", "Account");
			}
		}
	}
}
