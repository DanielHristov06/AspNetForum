using Dev.Service.Community;
using Dev.Service.Models;
using Dev.Service.Thread;
using Dev.Web.Models.Comment;
using Dev.Web.Models.Thread;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class ThreadController : Controller
    {
        private readonly IHubService _hubService;
        private readonly IThreadService _threadService;

        public ThreadController(IHubService hubService, IThreadService threadService)
        {
            _hubService = hubService;
            _threadService = threadService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["Hubs"] = _hubService.GetAll().ToList();

            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateThreadModel model)
        {
            await _threadService.CreateAsync(new ThreadServiceModel
            {
                Title = model.Title,
                Content = model.Content,
                Tags = model.Tags.Select(tag => new DevTagServiceModel { Label = tag }).ToList(),
                Hub = new HubServiceModel { Id = model.HubId }
            });

            return Redirect("/");
        }


        [HttpGet]
        public async Task<IActionResult> Details(string threadId)
        {
            ThreadServiceModel thread = await this._threadService.GetByIdAsync(threadId);

            //this.ViewData["Reactions"] = this._reactionService.GetAll().ToList();

            if (thread == null)
            {
                return NotFound("Thread not found...");
            }

            return View(thread);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(
            [FromForm] CreateCommentModel model,
            [FromQuery] string threadId,
            [FromQuery] string? parentId = null)
        {

            List<AttachmentServiceModel> commentAttachments = new List<AttachmentServiceModel>();

            if (model.Attachments != null)
            {
                //foreach (var attachment in model.Attachments)
                //{
                //    commentAttachments.Add(new AttachmentServiceModel
                //    {
                //        CloudUrl = await this.UploadFile(attachment)
                //    });
                //}
            }

            var result = await this._threadService.CreateCommentOnThread(new CommentServiceModel
            {
                Content = model.Content,
                Attachments = commentAttachments
            }, threadId, parentId);

            return Ok(result);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> React(
            [FromQuery] string threadId,
            [FromQuery] string reactionId)
        {
            var result = await this._threadService.CreateReactionOnThread(threadId, reactionId);

            return Ok(result);
        }

        //private async Task<string> UploadFile(IFormFile photo)
        //{
        //    var uploadResponse = await this._cloudinaryService.UploadFile(photo);

        //    if (uploadResponse == null)
        //    {
        //        return null;
        //    }

        //    return uploadResponse["url"].ToString();
        //}
    }
}