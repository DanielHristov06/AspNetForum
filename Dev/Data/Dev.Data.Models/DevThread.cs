
namespace Dev.Data.Models
{
    public class DevThread : MetadataBaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public Category Category { get; set; }

        public List<UserThreadReaction> Reactions { get; set; }

        public List<UserThreadComment> Comment { get; set; }
    }
}
