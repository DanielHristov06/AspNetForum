using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.Models
{
    public class UserThreadReactionServiceModel : BaseServiceModel
    {
        public DevUserServiceModel User { get; set; }

        public ThreadServiceModel Thread { get; set; }

        public ReactionServiceModel Reaction { get; set; }

        public bool IsDeleted { get; set; }
    }
}
