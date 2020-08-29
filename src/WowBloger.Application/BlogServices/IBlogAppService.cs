using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;
using WowBloger.BlogServices.Dto;

namespace WowBloger.BlogServices
{
    public interface IBlogAppService : IAsyncCrudAppService<BlogDto, Guid, PagedBlogResultRequestDto, CreateBlogDto, BlogDto>
    {
        Task<PagedResultDto<BlogDto>> GetAllByPopularity(PagedBlogResultRequestDto input);
    }
}
