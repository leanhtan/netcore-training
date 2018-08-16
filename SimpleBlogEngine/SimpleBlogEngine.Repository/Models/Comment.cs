using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogEngine.Repository.Models
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public long PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
