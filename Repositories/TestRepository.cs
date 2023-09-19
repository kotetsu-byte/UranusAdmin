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

        public async Task<IEnumerable<Test>> GetTestsAsync()
        {
            return await _context.Tests.Include(c => c.Course).ToListAsync();
        }

        public async Task<Test> GetTestByIdAsync(int id)
        {
            return await _context.Tests.Include(c => c.Course).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<string>> GetAllNamesOfCoursesAsync()
        {
            return await _context.Courses.Select(n => n.Name).ToListAsync();
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
