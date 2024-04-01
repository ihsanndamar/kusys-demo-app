using System.Data.SqlClient;
using System.Data;
using kusys_demo_app.Models;
using System.Reflection.PortableExecutable;
using kusys_demo_app.Mappers;

namespace kusys_demo_app.Data
{
    public class DataSeed
    {
        private readonly string connectionString;

        public DataSeed(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Seeding()
        {
            var roles = GetAllRoles();
            if (roles == null || roles.Count == 0)
            {
                AddNewRole("Admin");
                AddNewRole("Student");
                AddNewCourse("CSI101", "Introduction to Computer Science");
                AddNewCourse("CSI102", "Algorithms");
                AddNewCourse("MAT101", "Calculus");
                AddNewCourse("PHY101", "Physics");
            }

        }


        private void AddNewRole(string RoleName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddNewRole", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = RoleName;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddNewCourse(string CourseCode, string CourseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("AddNewCourse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@CourseCode", SqlDbType.NVarChar).Value = CourseCode;
                    command.Parameters.Add("@CourseName", SqlDbType.NVarChar).Value = CourseName;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private ICollection<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("GetAllRoles", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    

                    while (sqlDataReader.Read())
                    {
                        Role role = new Role();
                        roles.Add(RoleMapper.Map(role, sqlDataReader));
                    }
                }
            }
            return roles;
        }
    }
}
