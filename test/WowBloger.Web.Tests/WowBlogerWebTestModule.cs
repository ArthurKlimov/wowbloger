using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WowBloger.EntityFrameworkCore;
using WowBloger.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace WowBloger.Web.Tests
{
    [DependsOn(
        typeof(WowBlogerWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class WowBlogerWebTestModule : AbpModule
    {
        public WowBlogerWebTestModule(WowBlogerEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WowBlogerWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WowBlogerWebMvcModule).Assembly);
        }
    }
}