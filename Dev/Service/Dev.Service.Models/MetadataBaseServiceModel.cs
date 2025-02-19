using Dev.Service.Models;

namespace Dev.Service.Models
{
    public abstract class MetadataBaseServiceModel : BaseServiceModel
    {
        public DevUserServiceModel CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public DevUserServiceModel? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DevUserServiceModel? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }
    } 
}