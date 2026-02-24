using Microsoft.Data.SqlClient;
using System;
using System.Data;
public class Program
{
    public static void Main()
    {
        string connectionString =
            "Server=localhost\\SQLEXPRESS;" +
            "Database=ADO.NET;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;";
        try
        {
            string dept = Console.ReadLine();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Department", dept);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["EmpId"]} {reader["Name"]} {reader["Department"]} {reader["Phone"]} {reader["Email"]}");
                    }
                }
                using (SqlCommand cmd = new SqlCommand("sp_GetDepartmentEmployeeCount", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Department", dept);
                    cmd.Parameters.Add("@TotalEmployees", SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int totalCount = (int)cmd.Parameters["@TotalEmployees"].Value;
                    Console.WriteLine($"Total Employees in {dept} Department: {totalCount}");
                }
                using (SqlCommand cmd = new SqlCommand("sp_GetEmployeesOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Department"]} {reader["OrderId"]} {reader["OrderDate"]} {reader["OrderAmount"]}");
                    }
                }
                using (SqlCommand cmd = new SqlCommand("sp_GetDuplicateEmployees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["EmpId"]} {reader["Name"]} {reader["Department"]} {reader["Phone"]} {reader["Email"]}");
                    }
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