using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Repository.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
