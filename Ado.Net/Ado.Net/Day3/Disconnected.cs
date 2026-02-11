using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ado.Net.Day3
{
    public class Disconnected
    {
        public static void main()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;";
            DataSet ds=new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connection Successful!");
                    using (SqlCommand cmd = new SqlCommand("Select * from CollegeMaster", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds,"CollegeMaster");
                                            
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
