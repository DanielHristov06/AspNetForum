using System.Diagnostics;
using Dev.Service.Community;
using Dev.Service.Reaction;
using Dev.Service.Thread;
using Dev.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IThreadService _ThreadService;

        private readonly IReactionService _reactionService;

        public HomeController(IThreadService ThreadService, IReactionService reactionService)
        {
            _ThreadService = ThreadService;
            _reactionService = reactionService;
        }

        public IActionResult Index()
        {
            this.ViewData["Threads"] = this._ThreadService.GetAll().ToList();
            this.ViewData["Reactions"] = this._reactionService.GetAll().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}