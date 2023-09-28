using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> GetDocsAsync(int courseId, int lessonId);
        Task<Doc> GetDocByIdAsync(int courseId, int lessonId, int id);
        bool Create(Doc doc);
        bool Update(Doc doc);
        bool Delete(Doc doc);
        bool Save();
    }
}
