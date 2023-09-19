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
        [ForeignKey("Video")]
        public int? VideoId { get; set; }
        public ICollection<Video>? Videos { get; set; }
        [ForeignKey("Doc")]
        public int? DocId { get; set; }
        public ICollection<Doc>? Docs { get; set; }
        [ForeignKey("Homework")]
        public int? HomeworkId { get; set; }
        public ICollection<Homework>? Homeworks { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
