using System.ComponentModel.DataAnnotations;

namespace UranusAdmin.Models
{
    public class UserCourse
    {
        [Key]
        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public User? User { get; set; }
        public Course? Course { get; set; }
    }
}
