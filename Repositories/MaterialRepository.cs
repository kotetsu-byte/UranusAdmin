﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Material>> GetMaterialsAsync()
        {
            return await _context.Materials.Include(h => h.Homework).ToListAsync();
        }

        public async Task<Material> GetMaterialByIdAsync(int id)
        {
            return await _context.Materials.Include(h => h.Homework).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<string>> GetAllNamesOfHomeworksAsync()
        {
            return await _context.Homeworks.Select(h => h.Title).ToListAsync();
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