using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class VideoDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public Lesson? Lesson { get; set; }
        public List<string>? Lessons { get; set; }
    }
}
