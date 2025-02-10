
namespace Dev.Service.Models
{
    public class HubServiceModel : MetadataBaseServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public List<DevTagServiceModel> Tags { get; set; }

        public AttachmentServiceModel HubPhoto { get; set; }
        public AttachmentServiceModel BannerPhoto { get; set; }
    }
}