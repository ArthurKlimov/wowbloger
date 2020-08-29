using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using WowBloger.Blogs;
using WowBloger.BlogServices.Dto;
using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Authorization;
using WowBloger.Authorization;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace WowBloger.BlogServices
{
    [AbpAuthorize(PermissionNames.Pages_Blogs)]
    public class BlogAppService : AsyncCrudAppService<Blog, BlogDto, Guid, PagedBlogResultRequestDto, CreateBlogDto, BlogDto>, IBlogAppService
    {
        private readonly IRepository<Blog, Guid> _blogRepository;

        public BlogAppService(IRepository<Blog, Guid> blogRepository) : base(blogRepository)
        {
            _blogRepository = blogRepository;
        }
        
        [AbpAllowAnonymous]
        public async Task<PagedResultDto<BlogDto>> GetAllByPopularity(PagedBlogResultRequestDto input)
        {
            var blogs = await _blogRepository.GetAllIncluding(x => x.Articles)
                                             .OrderByDescending(x => x.Articles.Count)
                                             .ToListAsync();

            var count = blogs.Count;

            blogs = blogs.Skip(input.SkipCount)
                         .Take(input.MaxResultCount)
                         .ToList();

            var blogDtos = ObjectMapper.Map<List<BlogDto>>(blogs);

            return new PagedResultDto<BlogDto>(count, blogDtos);
        }
    }
}
