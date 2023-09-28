using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DataContext _context;

        public MaterialRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetMaterialsAsync(int courseId, int lessonId, int homeworkId)
        {
            return await _context.Materials.Where(m => m.Course.Id == courseId).Where(m => m.Lesson.Id == lessonId).Where(m => m.Homework.Id == homeworkId).ToListAsync();
        }

        public async Task<Material> GetMaterialByIdAsync(int courseId, int lessonId, int homeworkId, int id)
        {
            return await _context.Materials.Where(m => m.Course.Id == courseId).Where(m => m.Lesson.Id == lessonId).Where(m => m.Homework.Id == homeworkId).FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool Create(Material material)
        {
            _context.Materials.Add(material);

            return Save();
        }

        public bool Update(Material material)
        {
            _context.Materials.Update(material);

            return Save();
        }

        public bool Delete(Material material) 
        {
            _context.Materials.Remove(material);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
