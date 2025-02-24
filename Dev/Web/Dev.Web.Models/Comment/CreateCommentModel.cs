using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Dev.Web.Models.Comment
{
    public class CreateCommentModel
    {
        [Required(ErrorMessage = "Comment cannot be empty.")]
        public string Content { get; set; }

        public List<IFormFile> Attachments { get; set; }
    }
}