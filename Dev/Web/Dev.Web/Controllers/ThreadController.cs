using Dev.Web.Models.Thread;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class ThreadController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public IActionResult CreateConfirm(CreateThreadModel model)
        {
            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }
    }
}