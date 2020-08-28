using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using WowBloger.Configuration.Dto;

namespace WowBloger.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : WowBlogerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
