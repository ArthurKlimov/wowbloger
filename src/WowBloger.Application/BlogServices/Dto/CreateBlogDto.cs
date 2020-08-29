using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using WowBloger.Blogs;

namespace WowBloger.BlogServices.Dto
{
    [AutoMapTo(typeof(Blog))]
    public class CreateBlogDto
    {
        [Required]
        public string Title { get; set; }
    }
}
