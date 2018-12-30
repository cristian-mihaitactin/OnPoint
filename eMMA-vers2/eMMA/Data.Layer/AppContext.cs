using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public sealed class AppContext : DbContext
    {
        public DbSet<Student> Students { get; private set; }
        public DbSet<Professor> Professors { get; private set; }
        public DbSet<Attendance> Attendances { get; private set; }
        public DbSet<Mark> Marks { get; private set; }
        public DbSet<Homework> Homeworks { get; private set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
//            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.AttendanceList);
            modelBuilder.Entity<Student>()
                .HasMany(s => s.HomeworkList);
            modelBuilder.Entity<Student>()
                .HasMany(s => s.MarkList);
        }
    }
}

