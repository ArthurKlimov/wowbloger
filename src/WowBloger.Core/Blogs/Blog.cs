using Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WowBloger.Blogs
{
    [Table("Blogs")]
    public class Blog : AuditedEntity<Guid>
    {
        public Blog()
        {
            Articles = new List<Article>();
        }

        public Blog(string title) : this()
        {
            Title = title;
        }

        [Required]
        public string Title { get; set; }
        public List<Article> Articles { get; set; }
    }
}
