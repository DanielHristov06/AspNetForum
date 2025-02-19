using System.Diagnostics;
using Dev.Service.Community;
using Dev.Service.Thread;
using Dev.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IThreadService _threadService;

        public HomeController(ILogger<HomeController> logger, IThreadService threadService)
        {
            _logger = logger;
            _threadService = threadService;
        }

        public IActionResult Index()
        {
            ViewData["Threads"] = _threadService.GetAll().ToList();
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