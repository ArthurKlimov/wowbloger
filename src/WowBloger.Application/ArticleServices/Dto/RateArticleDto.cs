using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace WowBloger.ArticleServices.Dto
{
    public class RateArticleDto : EntityDto<Guid>
    {
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
    }
}
