using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using eMMA.Authorization.Roles;
using eMMA.Authorization.Users;
using eMMA.MultiTenancy;
using eMMA.Entities;
using User = eMMA.Authorization.Users.User;
using Abp.Domain.Repositories;
using eMMA.EntityFrameworkCore.Repositories;

namespace eMMA.EntityFrameworkCore
{
    public class eMMADbContext : AbpZeroDbContext<Tenant, Role, Authorization.Users.User, eMMADbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Student> Students { get; private set; }
        public DbSet<Professor> Professors { get; private set; }
        public DbSet<UniSubject> UniSubjects { get; private set; }
        public DbSet<SeminarInstance> Seminars { get; private set; }
        public DbSet<CourseInstance> Courses { get; private set; }
        public DbSet<LaboratoryInstance> Laboratories { get; private set; }
        public DbSet<File> Files { get; private set; }
        public DbSet<Question> Questions { get; private set; }
        public DbSet<Answer> Answers { get; private set; }
        public DbSet<Attendance> Attendances { get; private set; }
        public DbSet<Mark> Marks { get; private set; }
        public DbSet<Homework> Homeworks { get; private set; }

        public eMMADbContext(DbContextOptions<eMMADbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<User>().Ignore(u => u.DeleterUser);

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
            modelBuilder.Entity<SeminarInstance>()
                .HasMany(s => s.AttendingList);
            modelBuilder.Entity<SeminarInstance>()
                .HasMany(s => s.FileList);
            modelBuilder.Entity<SeminarInstance>()
                .HasMany(s => s.QuestionList);
            modelBuilder.Entity<SeminarInstance>()
                .HasMany(s => s.MarkList);
            modelBuilder.Entity<SeminarInstance>()
                .HasMany(s => s.AttendingList);
            modelBuilder.Entity<LaboratoryInstance>()
                .HasMany(s => s.FileList);
            modelBuilder.Entity<LaboratoryInstance>()
                .HasMany(s => s.QuestionList);
            modelBuilder.Entity<LaboratoryInstance>()
                .HasMany(s => s.MarkList);
            modelBuilder.Entity<CourseInstance>()
                .HasMany(s => s.AttendingList);
            modelBuilder.Entity<CourseInstance>()
                .HasMany(s => s.FileList);
            modelBuilder.Entity<CourseInstance>()
                .HasMany(s => s.QuestionList);
        }
    }
}
