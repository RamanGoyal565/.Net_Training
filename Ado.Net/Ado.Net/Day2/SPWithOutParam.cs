using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ado.Net.Day2
{
    public class SPWithOutParam
    {
        public static void main()
        {
            string connectionString ="Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connection successful");
                    using (SqlCommand cmd = new SqlCommand("USP_StudentPassByGrace", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@grace", SqlDbType.Int).Value = 5;
                        SqlParameter outputParam1 = new SqlParameter("@GracePass", SqlDbType.Int);
                        outputParam1.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam1);
                        SqlParameter outputParam2 = new SqlParameter("@Pass", SqlDbType.Int);
                        outputParam2.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam2);
                        cmd.ExecuteNonQuery();
                        int GracePass = (int)outputParam1.Value;
                        int Pass = (int)outputParam2.Value;
                        Console.WriteLine($"Grace Pass {GracePass} Pass {Pass}");
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
