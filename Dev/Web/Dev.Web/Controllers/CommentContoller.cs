using Dev.Service.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> React(
            [FromQuery] string commentId,
            [FromQuery] string reactionId)
        {
            var result = await _commentService.CreateReactionOnComment(commentId, reactionId);

            return Ok(result);
        }
    }
}