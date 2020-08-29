using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using WowBloger.Blogs;

namespace WowBloger.BlogServices.Dto
{
    [AutoMapFrom(typeof(Blog))]
    public class BlogDto : AuditedEntityDto<Guid>
    {
        public string Title { get; set; }

    }
}
