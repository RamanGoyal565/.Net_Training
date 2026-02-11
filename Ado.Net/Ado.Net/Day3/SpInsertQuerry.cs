using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ado.Net.Day3
{
    public class SpInsertQuerry
    {
        public static void main() 
        { 
            string connectionString =
                "Server=localhost\\SQLEXPRESS;" +
                "Database=TEST;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertHostel", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows Affected {rows}");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
