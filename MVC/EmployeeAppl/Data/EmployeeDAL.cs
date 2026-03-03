using EmployeeAppl.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeAppl.Data
{
    public class EmployeeDAL
    {
        private readonly string _connectionString;

        public EmployeeDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // CREATE
        public void AddEmployee(Employee emp)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = @"INSERT INTO Employees 
                            (Name, Address, Adhaar, DateOfBirth)
                            VALUES (@Name, @Address, @Adhaar, @DateOfBirth)";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.Parameters.AddWithValue("@Adhaar", emp.Adhaar);
            cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // READ ALL
        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            using SqlConnection con = new SqlConnection(_connectionString);
            string query = "SELECT * FROM Employees";

            using SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Employee
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Address"].ToString(),
                    Adhaar = Convert.ToInt64(reader["Adhaar"]),
                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"])
                });
            }

            return list;
        }

        // UPDATE
        public void UpdateEmployee(Employee emp)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = @"UPDATE Employees SET 
                            Name=@Name,
                            Address=@Address,
                            Adhaar=@Adhaar,
                            DateOfBirth=@DateOfBirth
                            WHERE Id=@Id";

            using SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.Parameters.AddWithValue("@Adhaar", emp.Adhaar);
            cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
            cmd.Parameters.AddWithValue("@Id", emp.Id);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        public void DeleteEmployee(int id)
        {
            using SqlConnection con = new SqlConnection(_connectionString);

            string query = "DELETE FROM Employees WHERE Id=@Id";

            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
