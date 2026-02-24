using CRUD_WebApllication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUD_WebApllication.Controllers
{
    public class StudentController : Controller
    {
        private readonly string connectionString;

        public StudentController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IActionResult Index()
        {
            return View();
        }
        // CREATE
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Student (Name, Age) VALUES (@Name, @Age)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        // READ (Separate Page)
        public IActionResult Read()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Student";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = (int)reader["Age"]
                    });
                }
            }

            return View(students);
        }

        // UPDATE
        public IActionResult Update(int? id, Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // STEP 1: If ID is given but name is empty → fetch old data
                if (id.HasValue && student.Name==null)
                {
                    string selectQuery = "SELECT * FROM Student WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(selectQuery, con);
                    cmd.Parameters.AddWithValue("@Id", id.Value);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        student.Id = (int)reader["Id"];
                        student.Name = reader["Name"].ToString();
                        student.Age = (int)reader["Age"];
                    }

                    return View(student);
                }

                // STEP 2: If ID + new data given → update
                if (student.Id!=0)
                {
                    if (ModelState.IsValid)
                    {
                        string updateQuery = "UPDATE Student SET Name=@Name, Age=@Age WHERE Id=@Id";
                        SqlCommand cmd = new SqlCommand(updateQuery, con);

                        cmd.Parameters.AddWithValue("@Id", id.Value);
                        cmd.Parameters.AddWithValue("@Name", student.Name);
                        cmd.Parameters.AddWithValue("@Age", student.Age.Value);

                        cmd.ExecuteNonQuery();

                        return RedirectToAction("Index");
                    }

                }
            }

            return View();
        }

        // DELETE
        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Student WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Id", id.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}