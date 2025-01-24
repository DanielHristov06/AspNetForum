using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Models
{
    public class Comment : MetadataBaseEntity
    {
        public string Content { get; set; }

        public List<Attachment> Attachments { get; set; }

        public List<UserCommentReaction> Reactions { get; set; }

        public List<Comment> Replies { get; set; }
    }
}
