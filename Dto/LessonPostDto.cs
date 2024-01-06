using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class LessonPostDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
    }
}
