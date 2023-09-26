using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetTestsAsync();
        Task<Test> GetTestByIdAsync(int id);
        Task<List<Course>> GetAllCoursesAsync();
        bool Create(Test test);
        bool Update(Test test);
        bool Delete(Test test);
        bool Save();
    }
}
