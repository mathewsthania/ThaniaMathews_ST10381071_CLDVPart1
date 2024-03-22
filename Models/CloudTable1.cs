using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CLDV_ASSIGNMENT.Models
{
	public class CloudTable1 : Controller
	{
		public static string con_string = "Server=tcp:sql-databaset-utorial.database.windows.net,1433;Initial Catalog=SQLDatabase;Persist Security Info=False;User ID=thaniamathews;Password=SummerMe26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
		public static SqlConnection con = new SqlConnection(con_string);
		public IActionResult Index()
		{
			return View();
		}
	}
}
