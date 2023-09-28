using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class MaterialDto
    {
        public int? Id
        {
            get; set;
        }
        public string? Title
        {
            get; set;
        }
        public string? Url
        {
            get; set;
        }
        public Homework? Homework { get; set; }
        public int? HomeworkId { get; set; }
        public Lesson? Lesson { get; set; }
        public int? LessonId { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
    } 
}
