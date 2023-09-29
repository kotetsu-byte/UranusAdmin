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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Lesson>()
                .HasOne(l => l.Course)
                .WithMany(t => t.Lessons)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Test>()
                .HasOne(t => t.Course)
                .WithMany(t => t.Tests)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Homework>()
                .HasOne(h => h.Lesson)
                .WithMany(t => t.Homeworks)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Video>()
                .HasOne(v => v.Lesson)
                .WithMany(t => t.Videos)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Doc>()
                .HasOne(d => d.Lesson)
                .WithMany(t => t.Docs)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Material>()
                .HasOne(m => m.Homework)
                .WithMany(t => t.Materials)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
