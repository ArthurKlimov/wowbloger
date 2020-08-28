using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WowBloger.Authorization;

namespace WowBloger
{
    [DependsOn(
        typeof(WowBlogerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WowBlogerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WowBlogerAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WowBlogerApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
