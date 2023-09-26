using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UranusAdmin.Models
{
    public class Lesson
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public ICollection<Video>? Videos { get; set; }
        public ICollection<Doc>? Docs { get; set; }
        public ICollection<Homework>? Homeworks { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
