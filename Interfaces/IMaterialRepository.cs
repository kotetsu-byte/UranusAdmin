using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetMaterialsAsync(int courseId, int lessonId,int homeworkId);
        Task<Material> GetMaterialByIdAsync(int courseId, int lessonId, int homeworkId, int id);
        bool Create(Material material);
        bool Update(Material material);
        bool Delete(Material material);
        bool Save();
    }
}
