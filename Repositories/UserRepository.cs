using Microsoft.EntityFrameworkCore;
using UranusAdmin.Data;
using UranusAdmin.Interfaces;
using UranusAdmin.Models;

namespace UranusAdmin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync() 
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public bool Create(User user)
        {
            _context.Users.Add(user);

            return Save();
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);

            return Save();
        }

        public bool Delete(User user)
        {
            _context.Users.Remove(user);

            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
