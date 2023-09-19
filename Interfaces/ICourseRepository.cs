using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        bool Create(Course course);
        bool Update(Course course);
        bool Delete(Course course);
        bool Save();
    }
}
