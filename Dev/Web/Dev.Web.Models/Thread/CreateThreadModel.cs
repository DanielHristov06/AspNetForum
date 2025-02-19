using Dev.Web.Models.Utilities.Binding;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Models.Thread
{
    public class CreateThreadModel
    {
        public string HubId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [BindProperty(BinderType = typeof(TagsModelBinder))]
        public List<string> Tags { get; set; }
        public List<string> TagsIds { get; set; }
    }
}