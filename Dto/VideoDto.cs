using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class VideoDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? VideoName { get; set; }
        public IFormFile? VideoContent { get; set; }
        public Lesson? Lesson { get; set; }
        public int? LessonId { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
    }
}
