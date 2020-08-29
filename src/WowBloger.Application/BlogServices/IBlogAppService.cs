using Abp.Application.Services;
using System;
using WowBloger.BlogServices.Dto;

namespace WowBloger.BlogServices
{
    public interface IBlogAppService : IAsyncCrudAppService<BlogDto, Guid, PagedBlogResultRequestDto, CreateBlogDto, BlogDto>
    {
    }
}
