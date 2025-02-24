using Dev.Service.Comment;
using Dev.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dev.Web.ViewComponents
{

    [ViewComponent]
    public class ThreadCommentViewComponent : ViewComponent
    {
        private readonly ICommentService commentService;

        public ThreadCommentViewComponent(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? threadId = null, string? parentId = null, List<ReactionServiceModel> reactions = null)
        {
            ViewData["Reactions"] = reactions ?? new List<ReactionServiceModel>();

            if (threadId != null)
            {
                var threadComments = (await commentService.GetAllByThreadId(threadId)).ToList();
                return View(threadComments);
            }

            if (parentId != null)
            {
                var parentComments = await commentService.GetAllByParentId(parentId).ToListAsync();
                return View(parentComments);
            }

            return View(new List<CommentServiceModel>());
        }
    }
}