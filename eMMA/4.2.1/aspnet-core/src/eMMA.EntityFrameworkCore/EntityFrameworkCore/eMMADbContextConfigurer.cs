using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace eMMA.EntityFrameworkCore
{
    public static class eMMADbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<eMMADbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<eMMADbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
