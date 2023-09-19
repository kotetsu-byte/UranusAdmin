using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Video>> GetVideosAsync()
        {
            return await _context.Videos.Include(l => l.Lesson).ToListAsync();
        }

        public async Task<Video> GetVideoByIdAsync(int id)
        {
            return await _context.Videos.Include(l => l.Lesson).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<string>> GetAllNamesOfLessonsAsync()
        {
            return await _context.Lessons.Select(l => l.Title).ToListAsync();
        }

        public bool Create(Video video)
        {
            _context.Videos.Add(video);

            return Save();
        }

        public bool Update(Video video)
        {
            _context.Videos.Update(video);

            return Save();
        }

        public bool Delete(Video video) 
        { 
            _context.Videos.Remove(video);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
