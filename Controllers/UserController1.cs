using KhumaloCraftEmporium.Models;
using Microsoft.AspNetCore.Mvc;

namespace KhumaloCraftEmporium.Controllers
{
	public class UserController1 : Controller
	{
		// instantiate UserTable object to interact with the database
		public UserTable usrtbl = new UserTable();

		// Action method to handle SignUp POST request
		[HttpPost]
		public ActionResult SignUp(UserTable Users)
		{
			// call insert_User method of UserTable to insert user data into the database
			var result = usrtbl.insert_User(Users);
			
			// redirecting to Home/Index action after a successful SignUp
			return RedirectToAction("Login", "Home");
		}

		// Action Method to handle SignUp GET request
		[HttpGet]
		public ActionResult SignUp()
		{
			// return the SignUp view with the UserTable object
			return View(usrtbl);
		}
	}
}
