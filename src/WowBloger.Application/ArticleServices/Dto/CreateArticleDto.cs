using Abp.AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using WowBloger.Blogs;

namespace WowBloger.ArticleServices.Dto
{
    [AutoMapFrom(typeof(Article))]
    public class CreateArticleDto
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public Guid BlogId { get; set; }
    }
}
