using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IHomeworkRepository
    {
        Task<IEnumerable<Homework>> GetHomeworksAsync(int courseId, int lessonId);
        Task<Homework> GetHomeworkByIdAsync(int courseId, int lessonId, int id);
        bool Create(Homework homework);
        bool Update(Homework homework);
        bool Delete(Homework homework);
        bool Save();
    }
}
