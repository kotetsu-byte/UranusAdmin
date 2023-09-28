using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _context;

        public TestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Test>> GetTestsAsync(int courseId)
        {
            return await _context.Tests.Where(t => t.Course.Id == courseId).ToListAsync();
        }

        public async Task<Test> GetTestByIdAsync(int courseId, int id)
        {
            return await _context.Tests.Where(t => t.Course.Id == courseId).FirstOrDefaultAsync(t => t.Id == id);
        }

        public bool Create(Test test)
        {
            _context.Tests.Add(test);

            return Save();
        }

        public bool Update(Test test)
        {
            _context.Tests.Update(test);

            return Save();
        }

        public bool Delete(Test test)
        {
            _context.Tests.Remove(test);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
