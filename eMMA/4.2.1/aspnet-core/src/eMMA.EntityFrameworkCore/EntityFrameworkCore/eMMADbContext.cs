using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using eMMA.Authorization.Roles;
using eMMA.Authorization.Users;
using eMMA.MultiTenancy;

namespace eMMA.EntityFrameworkCore
{
    public class eMMADbContext : AbpZeroDbContext<Tenant, Role, User, eMMADbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public eMMADbContext(DbContextOptions<eMMADbContext> options)
            : base(options)
        {
        }
    }
}
