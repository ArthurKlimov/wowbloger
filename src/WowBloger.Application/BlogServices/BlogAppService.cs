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

namespace WowBloger.BlogServices
{
    public class BlogAppService : AsyncCrudAppService<Blog, BlogDto, Guid, PagedBlogResultRequestDto, CreateBlogDto, BlogDto>, IBlogAppService
    {
        private readonly IRepository<Blog, Guid> _blogRepository;

        public BlogAppService(IRepository<Blog, Guid> blogRepository, IAbpSession abpSession) : base(blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [AbpAuthorize(PermissionNames.Pages_Blogs)]
        public override async Task<BlogDto> CreateAsync(CreateBlogDto input)
        {
            var blog = ObjectMapper.Map<Blog>(input);
            await _blogRepository.InsertAsync(blog);

            return MapToEntityDto(blog);
        }

        [AbpAuthorize(PermissionNames.Pages_Blogs)]
        public override async Task DeleteAsync(EntityDto<Guid> input)
        {
            var blog = await _blogRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (blog != null)
            {
                await _blogRepository.DeleteAsync(blog);
            }
        }

        public override async Task<PagedResultDto<BlogDto>> GetAllAsync(PagedBlogResultRequestDto input)
        {
            var blogs = await _blogRepository.GetAllListAsync();

            return new PagedResultDto<BlogDto>(blogs.Count, (IReadOnlyList<BlogDto>)blogs);
        }

        public override async Task<BlogDto> GetAsync(EntityDto<Guid> input)
        {
            var blog = await _blogRepository.FirstOrDefaultAsync(x => x.Id == input.Id);

            return blog != null ? MapToEntityDto(blog) : new BlogDto();
        }

        [AbpAuthorize(PermissionNames.Pages_Blogs)]
        public override async Task<BlogDto> UpdateAsync(BlogDto input)
        {
            var blog = await _blogRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (blog != null)
            {
                await _blogRepository.UpdateAsync(blog);
            }

            return new BlogDto();
        }
    }
}
