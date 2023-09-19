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

        public async Task<IEnumerable<Doc>> GetDocsAsync()
        {
            return await _context.Docs.Include(l => l.Lesson).ToListAsync();
        }

        public async Task<Doc> GetDocByIdAsync(int id)
        {
            return await _context.Docs.Include(l => l.Lesson).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<string>> GetAllNamesOfLessonsAsync()
        {
            return await _context.Lessons.Select(l => l.Title).ToListAsync();
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
