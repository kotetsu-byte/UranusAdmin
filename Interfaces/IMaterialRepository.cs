using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<Material>> GetMaterialsAsync();
        Task<Material> GetMaterialByIdAsync(int id);
        Task<List<string>> GetAllNamesOfHomeworksAsync();
        bool Create(Material material);
        bool Update(Material material);
        bool Delete(Material material);
        bool Save();
    }
}
