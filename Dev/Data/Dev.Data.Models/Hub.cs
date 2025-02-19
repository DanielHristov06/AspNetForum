namespace Dev.Data.Models
{
    public class Hub : MetadataBaseEntity
    {

        public string Name {  get; set; }

        public string Description { get; set; }
        public List<DevTag> Tags { get; set; }

        public Attachment? HubPhoto { get; set; }
        public Attachment? BannerPhoto { get; set; }
    }
}