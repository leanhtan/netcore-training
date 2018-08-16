using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Repository.Models
{
    public class Post : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
