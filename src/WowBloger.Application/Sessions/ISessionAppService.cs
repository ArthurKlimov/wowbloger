using System.Threading.Tasks;
using Abp.Application.Services;
using WowBloger.Sessions.Dto;

namespace WowBloger.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
