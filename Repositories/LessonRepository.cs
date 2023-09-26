using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly DataContext _context;

        public LessonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(int id)
        {
            return await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public bool Create(Lesson lesson)
        {
            _context.Lessons.Add(lesson);

            return Save();
        }

        public bool Update(Lesson lesson)
        {
            _context.Lessons.Update(lesson);

            return Save();
        }

        public bool Delete(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
