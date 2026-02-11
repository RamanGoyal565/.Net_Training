using Microsoft.Data.SqlClient;
using System;

namespace Ado.Net.Day3
{
    public class MultipleQueries
    {
        public static void main()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;" + "Database=TEST;" + "Trusted_Connection=True;" + "TrustServerCertificate=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using SqlCommand cmd = new SqlCommand("Select count(*) from Hostel", conn);
                    int count = (int)cmd.ExecuteScalar();
                    Console.WriteLine(count);
                    if (count > 6) 
                    {
                        using (SqlCommand cmd1 = new SqlCommand("Delete from Hostel where StudentId=2", conn))
                        {
                            int rows = cmd1.ExecuteNonQuery();
                            Console.WriteLine(rows);
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd2 = new SqlCommand("Select * from Hostel", conn))
                        {
                            using (SqlDataReader reader = cmd2.ExecuteReader())
                            {
                                while (reader.Read())
                                    Console.WriteLine($"{reader.GetInt32(0)} {reader.GetInt32(1)} {reader.GetInt32(2)}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
