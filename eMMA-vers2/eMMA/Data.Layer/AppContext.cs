using Microsoft.EntityFrameworkCore;
using DataLayer.Models;

namespace DataLayer
{
    public sealed class AppContext : DbContext
    {
        public DbSet<Student> Students { get; private set; }
        public DbSet<Professor> Professors { get; private set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}

