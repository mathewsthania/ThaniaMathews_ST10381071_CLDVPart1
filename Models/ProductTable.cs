using System.Data.SqlClient;
using KhumaloCraftEmporium.Models;

namespace KhumaloCraft.Models
{
	public class ProductTable
	{
		// Connection string for connecting to the SQL database
		public static string con_string = "Server=tcp:sql-databaset-utorial.database.windows.net,1433;Initial Catalog=SQLDatabase;Persist Security Info=False;User ID=thaniamathews;Password=SummerMe26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

		// SQLConnection objct. for managing the database connection
		public static SqlConnection con = new SqlConnection(con_string);


		// properties for storing the product information
		public int ProductID { get; set; }
		public string Name { get; set; }

		public string Price { get; set; }

		public string Category { get; set; }

		public string Availability { get; set; }

		

		// Method for inserting product data into the database
		public int insert_product(ProductTable model)
		{
			string sql = "INSERT INTO ProductTable1 (ProductName, ProductPrice, ProductCategory, ProductAvailability) VALUES (@Name, @Price, @Category, @Availability)";

			// create SQLCommand object with SQL query and SQLConnection
			using SqlCommand cmd = new SqlCommand(sql, con);

			// adding parameters to the SQL query
			cmd.Parameters.AddWithValue("@Name", model.Name);
			cmd.Parameters.AddWithValue("@Price", model.Price);
			cmd.Parameters.AddWithValue("@Category", model.Category);
			cmd.Parameters.AddWithValue("@Availability", model.Availability);

			// open the database connection
			con.Open();

			// executing the SQL query + getting the number of rows affected 
			int rowsAffected = cmd.ExecuteNonQuery();

			// close the database connection
			con.Close();

			// returns the number of rows affected by the query
			return rowsAffected;
		}
	}
}

