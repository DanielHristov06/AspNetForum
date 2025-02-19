using Dev.Service.Community;
using Dev.Service.Models;
using Dev.Service.Thread;
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
    }
}