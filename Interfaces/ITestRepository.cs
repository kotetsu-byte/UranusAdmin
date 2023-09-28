using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetTestsAsync(int courseId);
        Task<Test> GetTestByIdAsync(int courseId, int id);
        bool Create(Test test);
        bool Update(Test test);
        bool Delete(Test test);
        bool Save();
    }
}
