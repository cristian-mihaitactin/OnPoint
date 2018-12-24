using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public sealed class AppContext : DbContext
    {
        public DbSet<Student> Students { get; private set; }
        public DbSet<Professor> Professors { get; private set; }
        public DbSet<UniClass> UniClasses {get; private set;}
        public DbSet<Question> Questions {get; private set;}
        public DbSet<Answer> Answers {get; private set;}

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}

