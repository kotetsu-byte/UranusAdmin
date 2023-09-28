using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetVideosAsync(int courseId, int lessonId);
        Task<Video> GetVideoByIdAsync(int courseId, int lessonId, int id);
        bool Create(Video video);
        bool Update(Video video);
        bool Delete(Video video);
        bool Save();
    }
}
