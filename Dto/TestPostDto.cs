using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class TestPostDto
    {
        public string? Question { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public int? CorrectAnswer { get; set; }
        public int? Points { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
    }
}
