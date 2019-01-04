using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public sealed class AppContext : DbContext
    {
        public DbSet<Student> Students { get; private set; }
        public DbSet<Professor> Professors { get; private set; }
         public DbSet<UniSubject> UniSubjects {get; private set;}
        public DbSet<SeminarInstance> Seminars {get; private set;}
        public DbSet<CourseInstance> Courses {get;private set;}
        public DbSet<LaboratoryInstance> Laboratories {get; private set;}
        public DbSet<Question> Questions {get; private set;}
        public DbSet<Answer> Answers {get; private set;}
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
            modelBuilder.Entity<UniSubject>()
                 .HasMany(s => s.Labs);
            modelBuilder.Entity<UniSubject>()
                 .HasMany(s => s.Seminars);
            modelBuilder.Entity<UniSubject>()
                 .HasMany(s => s.Courses);
        }
    }
}

