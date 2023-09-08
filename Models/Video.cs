using System.ComponentModel.DataAnnotations;

namespace UranusAdmin.Models
{
    public class Video
    {
        [Key]
        public int? Id { get; set; }
        public string? Url { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
