using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> GetDocsAsync();
        Task<Doc> GetDocByIdAsync(int id);
        Task<List<string>> GetAllNamesOfLessonsAsync();
        bool Create(Doc doc);
        bool Update(Doc doc);
        bool Delete(Doc doc);
        bool Save();
    }
}
