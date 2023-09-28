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

        public LessonRepository()
        {
            
        }

        public async Task<IEnumerable<Lesson>> GetLessonsAsync(int courseId)
        {
            return await _context.Lessons.Where(l => l.Course.Id == courseId).ToListAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(int courseId, int id)
        {
            return await _context.Lessons.Where(l => l.Course.Id == courseId).FirstOrDefaultAsync(l => l.Id == id);
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
