using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using global::WebApplication_With_ADO.NET.Models;
using Microsoft.Extensions.Configuration;


namespace WebApplication_With_ADO.NET.Data
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name, M1, Location FROM CollegeMaster";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = (double)(decimal)reader["M1"],
                        City = reader["Location"].ToString()
                    });
                }
            }

            return students;
        }
    }
}