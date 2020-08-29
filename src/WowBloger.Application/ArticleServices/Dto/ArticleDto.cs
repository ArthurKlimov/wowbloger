using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WowBloger.Blogs;
using WowBloger.BlogServices.Dto;

namespace WowBloger.ArticleServices.Dto
{
    [AutoMapFrom(typeof(Article))]
    public class ArticleDto : AuditedEntityDto<Guid>
    {

        public ArticleDto()
        {

        }

        public ArticleDto(string text, Guid blogId)
        {
            Text = text;
            BlogId = blogId;
        }

        [Required]
        public string Text { get; set; }
       
        [Required]
        public Guid BlogId { get; set; }
    }
}
