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
        public ICollection<Test>? Tests { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
    }
}
