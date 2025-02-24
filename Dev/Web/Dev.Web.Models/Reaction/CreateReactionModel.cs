using Microsoft.AspNetCore.Http;

namespace Dev.Web.Models.Reaction
{
    public class CreateReactionModel
    {
        public string Label { get; set; }

        public IFormFile Reaction { get; set; }
    }
}
