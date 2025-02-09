using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Models
{
    public abstract class MetadataBaseEntity : BaseEntity
    {
        public DevUser CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DevUser UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public DevUser DeletedBy { get; set; }

        public DateTime DeletedOn { get; set; }
    }
}
