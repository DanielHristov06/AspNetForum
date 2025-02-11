namespace Dev.Web.Models.Thread
{
    public class CreateThreadModel
    {
        public string HubId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> TagsIds { get; set; }
    }
}