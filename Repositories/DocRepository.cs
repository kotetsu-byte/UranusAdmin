using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class DocRepository :IDocRepository
    {
        private readonly DataContext _context;

        public DocRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doc>> GetDocsAsync(int courseId, int lessonId)
        {
            return await _context.Docs.Where(d => d.Course.Id == courseId).Where(d => d.Lesson.Id == lessonId).ToListAsync();
        }

        public async Task<Doc> GetDocByIdAsync(int courseId, int lessonId, int id)
        {
            return await _context.Docs.Where(d => d.Course.Id == courseId).Where(d => d.Lesson.Id == lessonId).FirstOrDefaultAsync(d => d.Id == id);
        }

        public bool Create(Doc doc)
        {
            _context.Docs.Add(doc);

            return Save();
        }

        public bool Update(Doc doc)
        {
            _context.Docs.Update(doc);

            return Save();
        }

        public bool Delete(Doc doc)
        {
            _context.Docs.Remove(doc);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
