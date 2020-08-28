using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WowBloger.EntityFrameworkCore
{
    public static class WowBlogerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WowBlogerDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WowBlogerDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
