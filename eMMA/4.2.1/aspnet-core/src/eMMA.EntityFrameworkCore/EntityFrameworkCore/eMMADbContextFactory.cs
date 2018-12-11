using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using eMMA.Configuration;
using eMMA.Web;

namespace eMMA.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class eMMADbContextFactory : IDesignTimeDbContextFactory<eMMADbContext>
    {
        public eMMADbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<eMMADbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            eMMADbContextConfigurer.Configure(builder, configuration.GetConnectionString(eMMAConsts.ConnectionStringName));

            return new eMMADbContext(builder.Options);
        }
    }
}
