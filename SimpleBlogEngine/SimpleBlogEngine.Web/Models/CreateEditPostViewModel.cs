using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Web.Models
{
    public class CreateEditPostViewModel
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        [Range(1, int.MaxValue, ErrorMessage = "Please select a caterory!")]
        [Display(Name ="Category")]
        public long CategoryId { get; set; }
    }
}
