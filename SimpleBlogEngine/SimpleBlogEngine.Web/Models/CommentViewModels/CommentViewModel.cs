using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlogEngine.Web.Models.CommentViewModels
{
    public class CommentViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public long PostId { get; set; }

        public string AddedDate { get; set; }
    }
}
