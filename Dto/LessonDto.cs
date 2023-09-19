using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class LessonDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Course? Course { get; set; }
        public List<string> Courses { get; set; }
    }
}
