using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WowBloger.Authorization.Roles;
using WowBloger.Authorization.Users;
using WowBloger.MultiTenancy;
using WowBloger.Blogs;

namespace WowBloger.EntityFrameworkCore
{
    public class WowBlogerDbContext : AbpZeroDbContext<Tenant, Role, User, WowBlogerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Rate> Rates { get; set; }

        public WowBlogerDbContext(DbContextOptions<WowBlogerDbContext> options)
            : base(options)
        {
        }
    }
}
