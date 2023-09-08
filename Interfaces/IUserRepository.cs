using UranusAdmin.Models;

namespace UranusAdmin.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        bool Create(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
    }
}
