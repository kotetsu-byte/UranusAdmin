using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace UranusAdmin.Models
{
    public class Course
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        [ForeignKey("Test")]
        public int? TestId { get; set; }
        public ICollection<Test>? Tests { get; set; }
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
    }
}
