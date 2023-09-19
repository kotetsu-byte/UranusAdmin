using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool Create(Course course)
        {
            _context.Courses.Add(course);

            return Save();
        }

        public bool Update(Course course)
        {
            _context.Courses.Update(course);

            return Save();
        }

        public bool Delete(Course course) 
        {
            _context.Courses.Remove(course);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
