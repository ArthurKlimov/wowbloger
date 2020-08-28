using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WowBloger.Authorization.Roles;
using WowBloger.Authorization.Users;
using WowBloger.MultiTenancy;

namespace WowBloger.EntityFrameworkCore
{
    public class WowBlogerDbContext : AbpZeroDbContext<Tenant, Role, User, WowBlogerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WowBlogerDbContext(DbContextOptions<WowBlogerDbContext> options)
            : base(options)
        {
        }
    }
}
