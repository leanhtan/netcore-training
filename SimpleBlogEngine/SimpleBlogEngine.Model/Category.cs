using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Model
{
    public class Category : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
