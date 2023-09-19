using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UranusAdmin.Models
{
    public class Material
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        [ForeignKey("Homework")]
        public int? HomeworkId { get; set; }
        public Homework? Homework { get; set; }
    }
}
