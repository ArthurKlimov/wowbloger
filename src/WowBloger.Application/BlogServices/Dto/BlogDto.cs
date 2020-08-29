using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WowBloger.ArticleServices.Dto;
using WowBloger.Blogs;

namespace WowBloger.BlogServices.Dto
{
    [AutoMapFrom(typeof(Blog))]
    public class BlogDto : AuditedEntityDto<Guid>
    {
        public BlogDto()
        {
            Articles = new List<ArticleDto>();
        }

        [Required]
        public string Title { get; set; }

        public List<ArticleDto> Articles { get; set; }
    }
}
