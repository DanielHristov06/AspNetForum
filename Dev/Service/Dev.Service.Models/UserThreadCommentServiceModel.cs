using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.Models
{
    public class UserThreadCommentServiceModel : BaseServiceModel
    {
        public DevUserServiceModel User { get; set; }

        public ThreadServiceModel Thread { get; set; }

        public CommentServiceModel Comment { get; set; }
    }
}
