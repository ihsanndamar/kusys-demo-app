


using System.Data;

namespace kusys_demo_app.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public Role Role { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
