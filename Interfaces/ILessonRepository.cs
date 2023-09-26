﻿using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetLessonsAsync();
        Task<Lesson> GetLessonByIdAsync(int id);
        Task<List<Course>> GetAllCoursesAsync();
        bool Create(Lesson lesson);
        bool Update(Lesson lesson);
        bool Delete(Lesson lesson);
        bool Save();
    }
}
