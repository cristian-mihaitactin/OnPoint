using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public sealed class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
//            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; private set; }
    }
}

