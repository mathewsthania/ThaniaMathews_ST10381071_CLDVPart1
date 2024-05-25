﻿using System;
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
		public string ProductImagePath { get; set; } // adding ProductImagePath to store image paths for each product
		public string ProductDescription { get; set; } // adding ProductDescription to store descriptions for each product 
		public ProductDisplayModel() { }

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

			string con_string = "Server=tcp:sql-databaset-utorial.database.windows.net,1433;Initial Catalog=SQLDatabase;Persist Security Info=False;User ID=thaniamathews;Password=SummerMe26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
			using (SqlConnection con = new SqlConnection(con_string))
			{
				string sql = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability FROM ProductTable";
				SqlCommand cmd = new SqlCommand(sql, con);

				con.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					ProductDisplayModel product = new ProductDisplayModel();

					product.ProductID = Convert.ToInt32(reader["ProductID"]);
					product.ProductName = Convert.ToString(reader["ProductName"]);
					product.ProductPrice = Convert.ToDecimal(reader["ProdutPrice"]);
					product.ProductCategory = Convert.ToString(reader["ProductCategory"]);
					product.ProductAvailability = Convert.ToBoolean(reader["ProductAvailability"]);

					products.Add(product);
				}

				reader.Close();
			}

			return products;
		}
	}
}
