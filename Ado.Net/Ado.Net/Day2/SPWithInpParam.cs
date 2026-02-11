using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Ado.Net.Day2
{
    public class SPWithInpParam
    {
        public static void main()
        {
            string connectionString =
                "Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connection successful");
                    using (SqlCommand cmd = new SqlCommand("USP_GetStudentNameByDept", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Dept", SqlDbType.NVarChar, 50).Value = "Btech";
                        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = "Male";

                        using SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]}");
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
