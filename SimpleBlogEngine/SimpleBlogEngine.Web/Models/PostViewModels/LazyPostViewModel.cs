using System.Collections.Generic;

namespace SimpleBlogEngine.Web.Models.PostViewModels
{
    public class LazyPostViewModel
    {
        public long Total { get; set; }
        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
    }
}
