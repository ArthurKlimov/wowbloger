using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WowBloger.Configuration;
using WowBloger.Web;

namespace WowBloger.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class WowBlogerDbContextFactory : IDesignTimeDbContextFactory<WowBlogerDbContext>
    {
        public WowBlogerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WowBlogerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            WowBlogerDbContextConfigurer.Configure(builder, configuration.GetConnectionString(WowBlogerConsts.ConnectionStringName));

            return new WowBlogerDbContext(builder.Options);
        }
    }
}
