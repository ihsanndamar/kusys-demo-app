using kusys_demo_app.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Data.SqlClient;

namespace kusys_demo_app.Mappers
{
    public static class RoleMapper
    {
        public static Role Map(Role role, SqlDataReader reader)
        {
            role.RoleId = int.Parse(reader["RoleId"].ToString());
            role.RoleName = reader["RoleName"].ToString();
            role.CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString());
            return role;
        }
    }
}
