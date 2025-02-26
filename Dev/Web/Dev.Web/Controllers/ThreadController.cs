using Dev.Service.Cloud;
using Dev.Service.Community;
using Dev.Service.Models;
using Dev.Service.Reaction;
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
        private readonly IReactionService _reactionService;
        private readonly ICloudinaryService _cloudinaryService;

        public ThreadController(IHubService hubService, IThreadService threadService, IReactionService reactionService, ICloudinaryService cloudinaryService)
        {
            _hubService = hubService;
            _threadService = threadService;
            _reactionService = reactionService;
            _cloudinaryService = cloudinaryService;
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
            List<AttachmentServiceModel> threadAttachments = new List<AttachmentServiceModel>();

            foreach (var attachment in model.Attachments)
            {
                threadAttachments.Add(new AttachmentServiceModel
                {
                    CloudUrl = await UploadFile(attachment)
                });
            }

            await _threadService.CreateAsync(new ThreadServiceModel
            {
                Title = model.Title,
                Content = model.Content,
                Tags = model.Tags.Select(tag => new DevTagServiceModel { Label = tag }).ToList(),
                Hub = new HubServiceModel
                {
                    Id = model.HubId
                },
                Attachments = threadAttachments
            });

            // TODO: Redirect to Thread Page
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string threadId)
        {
            ThreadServiceModel thread = await _threadService.GetByIdAsync(threadId);

            ViewData["Reactions"] = _reactionService.GetAll().ToList();

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
                foreach (var attachment in model.Attachments)
                {
                    commentAttachments.Add(new AttachmentServiceModel
                    {
                        CloudUrl = await UploadFile(attachment)
                    });
                }
            }

            var result = await _threadService.CreateCommentOnThread(new CommentServiceModel
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
            var result = await _threadService.CreateReactionOnThread(threadId, reactionId);

            return Ok(result);
        }

        private async Task<string> UploadFile(IFormFile photo)
        {
            var uploadResponse = await _cloudinaryService.UploadFile(photo);

            if (uploadResponse == null)
            {
                return null;
            }

            return uploadResponse["url"].ToString();
        }
    }
}