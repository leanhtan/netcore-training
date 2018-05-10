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
    }
}
