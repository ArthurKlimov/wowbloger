using Abp.Application.Services;
using WowBloger.MultiTenancy.Dto;

namespace WowBloger.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

