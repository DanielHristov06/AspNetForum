using Dev.Service.Community;
using Dev.Service.Models;
using Dev.Web.Models.Community;
using Microsoft.AspNetCore.Mvc;
namespace Dev.Web.Controllers
{
    public class CommunityController : Controller
    {
        private readonly IHubService HubService;

        public CommunityController(IHubService hubService)
        {
            this.HubService = hubService;
        }
            
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateCommunityModel CreateCommunityModel)
        {
            await this.HubService.CreateAsync(new HubServiceModel
            {
                Name = CreateCommunityModel.Name,
                Description = CreateCommunityModel.Description,
                Tags = CreateCommunityModel.Tags.Select(tag => new DevTagServiceModel { Label = tag}).ToList()
            });


            return Redirect("/");
        }
    }
}
