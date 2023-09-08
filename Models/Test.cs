using System.ComponentModel.DataAnnotations;

namespace UranusAdmin.Models
{
    public class Test
    {
        [Key]
        public int? Id { get; set; }
        public string? Question { get; set; }
        public string[]? Answers { get; set; }
        public int? CorrectAnswer { get; set; }
        public int? Points { get; set; }
        public Course? Course { get; set; }
    }
}
