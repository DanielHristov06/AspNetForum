using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Models
{
    public class UserCommentReaction : BaseEntity
    {
        public DevUser User { get; set; }

        public Reaction Reaction { get; set; }

        public Comment Comment { get; set; }
    }
}
