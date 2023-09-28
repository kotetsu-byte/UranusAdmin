using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetLessonsAsync(int courseId);
        Task<Lesson> GetLessonByIdAsync(int courseId, int id);
        bool Create(Lesson lesson);
        bool Update(Lesson lesson);
        bool Delete(Lesson lesson);
        bool Save();
    }
}
