using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;

namespace UranusAdmin.Data
{
    public class DataContext : IdentityDbContext<Admin>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Material> Materials { get; set; }
    }
}
