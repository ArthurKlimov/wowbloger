using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WowBloger.Blogs
{
    public class Rate : AuditedEntity<Guid>
    {
        public Rate()
        {

        }

        public Rate(int value, Guid articleId)
        {
            Value = value;
            ArticleId = articleId;
        }

        public int Value { get; set; }

        [ForeignKey(nameof(ArticleId))]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
