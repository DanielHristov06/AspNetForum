using Dev.Service.Cloud;
using Dev.Service.Community;
using Dev.Service.Models;
using Dev.Web.Models.Community;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IHubService HubService;
        private readonly ICloudinaryService CloudinaryService;

        public CommunityController(IHubService hubService, ICloudinaryService cloudinaryService)
        {
            HubService = hubService;
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