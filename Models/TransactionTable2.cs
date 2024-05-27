using System;
using System.Data.SqlClient;

namespace KhumaloCraft.Models
{
    public class TransactionTable2
    {
        // Connection string for connecting to the SQL database
        private static string connectionString = "Server=tcp:sql-databaset-utorial.database.windows.net,1433;Initial Catalog=SQLDatabase;Persist Security Info=False;User ID=thaniamathews;Password=SummerMe26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        // Method for inserting order into the transactionTable2
        public static void InsertOrder(int userID, int productID)
        {
            try
            {
                // Define the SQL query to insert a new record into the transactionTable2
                string sql = "INSERT INTO transactionTable2 (UserID, ProductID) VALUES (@UserID, @ProductID)";

                // Create a new instance of SqlConnection with the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a new instance of SqlCommand with the SQL query and SqlConnection
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters to the SqlCommand for UserID and ProductID
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@ProductID", productID);

                        // Open the SqlConnection
                        connection.Open();

                        // Execute the SqlCommand to insert the record into the transactionTable2
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }
    }
}