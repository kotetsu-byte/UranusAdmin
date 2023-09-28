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

        public async Task<IEnumerable<Video>> GetVideosAsync(int courseId, int lessonId)
        {
            return await _context.Videos.Where(v => v.Course.Id == courseId).Where(v => v.Lesson.Id == lessonId).ToListAsync();
        }

        public async Task<Video> GetVideoByIdAsync(int courseId, int lessonId, int id)
        {
            return await _context.Videos.Where(v => v.Course.Id == courseId).Where(v => v.Lesson.Id == lessonId).FirstOrDefaultAsync(v => v.Id == id);
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
