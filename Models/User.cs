using System.ComponentModel.DataAnnotations;

namespace UranusAdmin.Models
{
    public class User
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Username { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}
