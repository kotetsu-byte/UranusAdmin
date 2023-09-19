using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UranusAdmin.Models;

namespace UranusAdmin.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<UserCourse> UserCourses { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>()
                .HasKey(uc => new { uc.UserId, uc.CourseId });
            modelBuilder.Entity<UserCourse>()
                .HasOne(u => u.User)
                .WithMany(uc => uc.UserCourses)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserCourse>()
                .HasOne(c => c.Course)
                .WithMany(uc => uc.UserCourses)
                .HasForeignKey(c => c.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
