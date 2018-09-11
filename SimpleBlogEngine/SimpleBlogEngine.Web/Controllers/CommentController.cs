using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;
using SimpleBlogEngine.Web.Models.CommentViewModels;

namespace SimpleBlogEngine.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CommentController : Controller
    {
        ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("{id}", Name = "GetByPost")]
        public async Task<List<CommentViewModel>> GetByPost(long id)
        {
            var comments = new List<CommentViewModel>();
            var commentCollection = await commentService.GetByPost(id);
            commentCollection.ToList().ForEach(c =>
            {
                var comment = new CommentViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Content = c.Content,
                    AddedDate = c.AddedDate.ToString("MMM dd yyyy, hh:mm tt (UTC)")
                };
                comments.Add(comment);
            });
            return comments;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment([FromBody] CommentViewModel commentViewModel)
        {
            await commentService.Insert(new Comment {
               AddedDate = DateTime.UtcNow,
               Name = commentViewModel.Name,
               Content = commentViewModel.Content,
               IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
               PostId = commentViewModel.PostId
            });
            return NoContent();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(long id)
        {
            await commentService.Delete(id);
            return NoContent();
        }
    }
}
