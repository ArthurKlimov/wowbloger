using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WowBloger.Blogs
{
    public class Article : AuditedEntity<Guid>
    {
        public Article()
        {
            Rates = new List<Rate>();
        }

        public Article(string text, Guid blogId)
        {
            Text = text;
            BlogId = blogId;
        }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid BlogId { get; set; }

        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; }

        public List<Rate> Rates { get; set; }
    }
}
