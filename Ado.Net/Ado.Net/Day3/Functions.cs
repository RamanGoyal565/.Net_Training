using System;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Ado.Net.Day3
{
    public class Functions
    {
        public static void main()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string querry = "Select dbo.HighestM2()";
                    conn.Open();
                    Console.WriteLine("Connection successful");
                    using (SqlCommand cmd = new SqlCommand(querry, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        int highestM2=Convert.ToInt32(cmd.ExecuteScalar());
                        Console.WriteLine(highestM2);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
