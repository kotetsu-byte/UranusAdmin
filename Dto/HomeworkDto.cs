using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class HomeworkDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? Deadline { get; set; }
        public Lesson? Lesson { get; set; }
        public int? LessonId { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
    }
}
