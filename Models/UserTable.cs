﻿using KhumaloCraftEmporium.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace KhumaloCraftEmporium.Models
{
	public class UserTable
	{
		// Connection string for connecting to the SQL database
		public static string con_string = "Server=tcp:sql-databaset-utorial.database.windows.net,1433;Initial Catalog=SQLDatabase;Persist Security Info=False;User ID=thaniamathews;Password=SummerMe26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
		
		// SQLConnection objct. for managing the database connection
		public static SqlConnection con = new SqlConnection(con_string);


		// properties for storing the user information
		public string Name { get; set; }

		public string Surname { get; set; }
		
		public string Email { get; set; }

		public string Password { get; set; }


		// Method for inserting user data into the database
		public int insert_User(UserTable model)
		{
			string sql = "INSERT INTO UserTable (UserName, UserSurname, UserEmail, UserPassword) VALUES (@Name, @Surname, @Email, @Password)";
			
			// create SQLCommand object with SQL query and SQLConnection
			using SqlCommand cmd = new SqlCommand(sql, con);

			// adding parameters to the SQL query
			cmd.Parameters.AddWithValue("@Name", model.Name);
			cmd.Parameters.AddWithValue("@Surname", model.Surname);
			cmd.Parameters.AddWithValue("@Email", model.Email);
            cmd.Parameters.AddWithValue("@Password", model.Password);

            // open the database connection
            con.Open();

			// executing the SQL query + getting the number of rows affected 
			int resultAffected = cmd.ExecuteNonQuery();

			// close the database connection
			con.Close();

			// returns the number of rows affected by the query
			return resultAffected;	
		}
	}
}

