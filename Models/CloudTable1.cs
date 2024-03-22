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

		public string Name { get; set; }

		public string Surname { get; set; }
		
		public string Email { get; set; }

		public int insert_User(CloudTable1 m)
		{
			string sql = "INSERT INTO CloudTable1 (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
			SqlCommand cmd = new SqlCommand(sql, con);

			cmd.Parameters.AddWithValue("@Name", m.Name);
			cmd.Parameters.AddWithValue("@Surname", m.Surname);
			cmd.Parameters.AddWithValue("@Email", m.Email);
			
			con.Open();
			int rowsAffected = cmd.ExecuteNonQuery();
			con.Close();

			return rowsAffected;	
		}
	}
}

