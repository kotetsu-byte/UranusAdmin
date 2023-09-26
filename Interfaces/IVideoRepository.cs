using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IVideoRepository
    {
        Task<IEnumerable<Video>> GetVideosAsync();
        Task<Video> GetVideoByIdAsync(int id);
        Task<List<Lesson>> GetAllLessonsAsync();
        bool Create(Video video);
        bool Update(Video video);
        bool Delete(Video video);
        bool Save();
    }
}
