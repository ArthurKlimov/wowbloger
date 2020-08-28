using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WowBloger.Configuration;

namespace WowBloger.Web.Host.Startup
{
    [DependsOn(
       typeof(WowBlogerWebCoreModule))]
    public class WowBlogerWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WowBlogerWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WowBlogerWebHostModule).GetAssembly());
        }
    }
}
