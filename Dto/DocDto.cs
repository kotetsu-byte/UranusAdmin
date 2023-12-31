﻿using UranusAdmin.Models;

namespace UranusAdmin.Dto
{
    public class DocDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? DocName { get; set; }
        public IFormFile? DocContent { get; set; }
        public Lesson? Lesson { get; set; } 
        public int? LessonId { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
    }
}
