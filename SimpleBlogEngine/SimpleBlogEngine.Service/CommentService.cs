using SimpleBlogEngine.Repository.Interfaces;
using SimpleBlogEngine.Repository.Models;
using SimpleBlogEngine.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlogEngine.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        readonly IGenericRepository<Comment> commentRepository;

        public CommentService(IGenericRepository<Comment> commentRepository) : base(commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetByPost(long id)
        {
            var comments = await commentRepository.GetAll();
            return comments.Where(x => x.PostId == id);
        }
    }
}
