using System.ComponentModel.DataAnnotations;

namespace UranusAdmin.Models
{
    public class Material
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public Homework? Homework { get; set; }
    }
}
