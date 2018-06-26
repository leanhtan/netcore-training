using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Web.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
