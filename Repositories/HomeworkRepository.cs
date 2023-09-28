using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class HomeworkRepository : IHomeworkRepository
    {
        private readonly DataContext _context;

        public HomeworkRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Homework>> GetHomeworksAsync(int courseId, int lessonId)
        {
            return await _context.Homeworks.Where(h => h.Course.Id == courseId).Where(h => h.Lesson.Id == lessonId).ToListAsync();
        }

        public async Task<Homework> GetHomeworkByIdAsync(int courseId, int lessonId, int id)
        {
            return await _context.Homeworks.Where(h => h.Course.Id == courseId).Where(h => h.Lesson.Id == lessonId).FirstOrDefaultAsync(h => h.Id == id);
        }


        public bool Create(Homework homework)
        {
            _context.Homeworks.Add(homework);

            return Save();
        }

        public bool Update(Homework homework)
        {
            _context.Homeworks.Update(homework);

            return Save();
        }

        public bool Delete(Homework homework)
        {
            _context.Homeworks.Remove(homework);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
