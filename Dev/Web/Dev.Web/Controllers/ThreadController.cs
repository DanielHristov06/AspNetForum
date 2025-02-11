using Dev.Web.Models.Thread;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class ThreadController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateConfirm(CreateThreadModel model)
        {
            return View();
        }
    }
}