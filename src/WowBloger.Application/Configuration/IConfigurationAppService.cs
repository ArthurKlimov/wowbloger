using System.Threading.Tasks;
using WowBloger.Configuration.Dto;

namespace WowBloger.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
