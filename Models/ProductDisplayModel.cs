using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
	public class ProductDisplayModel
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public string ProductCategory { get; set; }
		public bool ProductAvailability { get; set; }

		public ProductDisplayModel() { }

		// initializing productdisplaymodel properties
		public ProductDisplayModel(int id, string name, decimal price, string category, bool availability)
		{
			ProductID = id;
			ProductName = name;
			ProductPrice = price;
			ProductCategory = category;
			ProductAvailability = availability;
		}

		public static List<ProductDisplayModel> SelectProducts()
		{
			List<ProductDisplayModel> products = new List<ProductDisplayModel>();

			// connection string to connect to the sql database
			string con_string = "Server=tcp:sql-databaset-utorial.database.windows.net,1433;Initial Catalog=SQLDatabase;Persist Security Info=False;User ID=thaniamathews;Password=SummerMe26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
			using (SqlConnection con = new SqlConnection(con_string))
			{
				// collecting product data
				string sql = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability FROM ProductTable1";
				SqlCommand cmd = new SqlCommand(sql, con);

				con.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					ProductDisplayModel product = new ProductDisplayModel();

					product.ProductID = Convert.ToInt32(reader["ProductID"]);
					product.ProductName = Convert.ToString(reader["ProductName"]);
					product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
					product.ProductCategory = Convert.ToString(reader["ProductCategory"]);
					product.ProductAvailability = Convert.ToBoolean(reader["ProductAvailability"]);

					products.Add(product); // adds product to the list
				}

				con.Close();
			}

			Console.WriteLine("Number of products fetched" + products.Count);

			return products; // returns the list of products
		}
	}
}
