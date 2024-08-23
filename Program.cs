using System;
using System.Data.SqlClient;

namespace SQLCRUDApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection string (replace with your own)
            var connectionString = "Server=LAPTOP-C2ALCQV0\\SQLEXPRESS;Database=testDB;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // CREATE
                string insertQuery = "INSERT INTO Users (Name, Age, Email) VALUES (@Name, @Age, @Email)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", "Jane Doe");
                    cmd.Parameters.AddWithValue("@Age", 28);
                    cmd.Parameters.AddWithValue("@Email", "jane.doe@example.com");
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record inserted.");
                }

                // READ
                string selectQuery = "SELECT * FROM Users";
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Email: {reader["Email"]}");
                        }
                    }
                }

                // UPDATE
                string updateQuery = "UPDATE Users SET Age = @Age WHERE Name = @Name";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Age", 29);
                    cmd.Parameters.AddWithValue("@Name", "Jane Doe");
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Record updated.");
                }

                // DELETE
                //string deleteQuery = "DELETE FROM Users WHERE Name = @Name";
                //using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                //{
                //   cmd.Parameters.AddWithValue("@Name", "Jane Doe");
                // cmd.ExecuteNonQuery();
                //Console.WriteLine("Record deleted.");
                // }
            }
        }
    }
}
