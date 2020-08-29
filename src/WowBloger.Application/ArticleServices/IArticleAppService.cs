using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Threading.Tasks;
using WowBloger.ArticleServices.Dto;

namespace WowBloger.ArticleServices
{
    public interface IArticleAppService : IAsyncCrudAppService<ArticleDto, Guid, PagedResultRequestDto, CreateArticleDto, ArticleDto>
    {
        Task<ArticleDto> RateArticle(RateArticleDto input);
        Task<int> GetMeanRate(EntityDto<Guid> input);
    }
}
