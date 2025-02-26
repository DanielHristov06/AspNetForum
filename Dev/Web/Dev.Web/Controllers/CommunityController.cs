using Dev.Service.Cloud;
using Dev.Service.Community;
using Dev.Service.Models;
using Dev.Service.Reaction;
using Dev.Service.Thread;
using Dev.Web.Models.Community;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IHubService HubService;
        private readonly IThreadService ThreadService;
        private readonly IReactionService ReactionService;
        private readonly ICloudinaryService CloudinaryService;

        public CommunityController(IHubService hubService, IThreadService threadService, IReactionService reactionService, ICloudinaryService cloudinaryService)
        {
            HubService = hubService;
            ThreadService = threadService;
            ReactionService = reactionService;
            CloudinaryService = cloudinaryService;
        }
            
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateCommunityModel CreateCommunityModel)
        {
            var hubPhotoUrl = await UploadPhoto(CreateCommunityModel.HubPhoto);
            var bannerPhotoUrl = await UploadPhoto(CreateCommunityModel.BannerPhoto);

            await HubService.CreateAsync(new HubServiceModel
            {
                Name = CreateCommunityModel.Name,
                Description = CreateCommunityModel.Description,
                Tags = CreateCommunityModel.Tags.Select(tag => new DevTagServiceModel { Label = tag}).ToList(),
                HubPhoto = new AttachmentServiceModel { CloudUrl = hubPhotoUrl },
                BannerPhoto = new AttachmentServiceModel { CloudUrl = bannerPhotoUrl }
            });


            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string communityId)
        {
            ViewData["Threads"] = ThreadService.GetAllByCommunityId(communityId).ToList();
            ViewData["Reactions"] = ReactionService.GetAll().ToList();
            return View(await HubService.GetByIdAsync(communityId));
        }

        private async Task<string> UploadPhoto(IFormFile photo)
        {
            var uploadResponse = await CloudinaryService.UploadFile(photo);

            if (uploadResponse == null)
            {
                return null;
            }

            return uploadResponse["url"].ToString();
        }
    }
}