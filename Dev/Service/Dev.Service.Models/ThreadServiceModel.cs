namespace Dev.Service.Models
{
    public class ThreadServiceModel : MetadataBaseServiceModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public List<AttachmentServiceModel> Attachments { get; set; }

        public HubServiceModel Hub { get; set; }
        public List<DevTagServiceModel> Tags { get; set; }

        public List<UserThreadReactionServiceModel> Reactions { get; set; }

        public List<UserThreadCommentServiceModel> Comments { get; set; }
    }
}