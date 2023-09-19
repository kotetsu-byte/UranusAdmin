﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UranusAdmin.Models
{
    public class Doc
    {
        [Key]
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        [ForeignKey("Lesson")]
        public int? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
