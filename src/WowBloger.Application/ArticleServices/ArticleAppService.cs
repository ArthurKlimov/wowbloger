using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WowBloger.ArticleServices.Dto;
using WowBloger.Blogs;
using WowBloger.BlogServices;

namespace WowBloger.ArticleServices
{
    public class ArticleAppService : AsyncCrudAppService<Article, ArticleDto, Guid, PagedResultRequestDto, CreateArticleDto, ArticleDto>, IArticleAppService
    {
        private readonly IRepository<Article, Guid> _articleRepository;
        private readonly IBlogAppService _blogAppService;
        private readonly IAbpSession _abpSession;

        public ArticleAppService(IRepository<Article, Guid> articleRepository, IBlogAppService blogAppService, IAbpSession abpSession) 
            : base(articleRepository)
        {
            _articleRepository = articleRepository;
            _blogAppService = blogAppService;
            _abpSession = abpSession;
        }

        [AbpAuthorize]
        public override async Task<ArticleDto> CreateAsync(CreateArticleDto input)
        {
            var blog = await _blogAppService.GetAsync(new EntityDto<Guid>(input.BlogId));
            if (blog == null)
            {
                throw new UserFriendlyException("This blog does not exist. Try again!");
            }

            var article = new Article(input.Text, input.BlogId);
            await _articleRepository.InsertAsync(article);

            var articleDto = ObjectMapper.Map<ArticleDto>(article);
            return articleDto;
        }

        [AbpAuthorize]
        public override async Task DeleteAsync(EntityDto<Guid> input)
        {
            var article = await _articleRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (article == null)
            {
                throw new UserFriendlyException("This article does not exist. Try again!");
            }

            long userId = _abpSession.UserId.Value;
            if (article.CreatorUserId != userId)
            {
                throw new UserFriendlyException("This is not your article. You cannot delete it!");
            }


            await _articleRepository.DeleteAsync(article);
        }

        [AbpAuthorize]
        public async Task<ArticleDto> RateArticle(RateArticleDto input)
        {
            long userId = _abpSession.UserId.Value;

            var article = await _articleRepository.GetAllIncluding(x => x.Rates)
                                                  .FirstOrDefaultAsync(x => x.Id == input.Id);
            if (article == null)
            {
                throw new UserFriendlyException("This article does not exist. Try again!");
            }

            if (article.Rates?.Find(x => x.CreatorUserId == userId) != null)
            {
                throw new UserFriendlyException("You have already rated the article!");
            }

            article.Rates.Add(new Rate(input.Rate, article.Id));
            await _articleRepository.UpdateAsync(article);

            return MapToEntityDto(article);
        }

        public async Task<int> GetMeanRate(EntityDto<Guid> input)
        {
            var article = await _articleRepository.GetAllIncluding(x => x.Rates)
                                                  .FirstOrDefaultAsync(x => x.Id == input.Id);
            if (article == null)
            {
                throw new UserFriendlyException("This article does not exist. Try again!");
            }

            var rateSum = 0;
            foreach (var rate in article.Rates)
            {
                rateSum += rate.Value;
            }

            var count = article.Rates.Count;

            return count == 0 ? 0 : rateSum / count;
        }
    }
}
