using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<IEnumerable<Homework>> GetHomeworksAsync();
        Task<Homework> GetHomeworkByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsAsync();
        bool Create(Homework homework);
        bool Update(Homework homework);
        bool Delete(Homework homework);
        bool Save();
    }
}
