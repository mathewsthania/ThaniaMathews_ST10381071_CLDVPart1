using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using KhumaloCraft.Models;
using KhumaloCraftEmporium.Models;

namespace KhumaloCraft.Models
{
	public class ProductTable1
	{
		// Connection string for connecting to the SQL database
		public static string con_string = "Server=tcp:sql-databaset-utorial.database.windows.net,1433;Initial Catalog=SQLDatabase;Persist Security Info=False;User ID=thaniamathews;Password=SummerMe26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";


		// properties for storing the product information
		public int ProductID { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string Category { get; set; }

		public bool Availability { get; set; }

        // SQLConnection objct. for managing the database connection
        public static SqlConnection con = new SqlConnection(con_string);

        // Method for inserting product data into the database
        public int insert_product(ProductTable1 model)
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

		public static List<ProductTable1> GetAllProducts()
		{
			List<ProductTable1> products = new List<ProductTable1>();

			using (SqlConnection con = new SqlConnection(con_string))
			{
				string sql = "SELECT * FROM ProductTable1";
				SqlCommand cmd = new SqlCommand(sql, con);

				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					ProductTable1 product = new ProductTable1();
					product.ProductID = Convert.ToInt32(rdr["ProductID"]);
					product.Name = rdr["ProductName"].ToString();
					product.Price = rdr["ProductPrice"] != DBNull.Value ? Convert.ToDecimal(rdr["ProductPrice"]) : 0;
                    product.Category = rdr["ProductCategory"].ToString();
					product.Availability = rdr["ProductAvailability"] != DBNull.Value ? Convert.ToBoolean(rdr["ProductAvailability"]) : false;

                    products.Add(product);
				}
			}

			return products;
		}
	}
}

