using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Models
{
    public class UserThreadComment : BaseEntity
    {
        public DevUser User { get; set; }

        public DevThread Thread { get; set; }

        public Comment Comment { get; set; }
    }
}
