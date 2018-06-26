using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Web.Models.PostViewModels
{
    public class PostViewModel
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
