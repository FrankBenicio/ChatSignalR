using ChatSignalR.Models;
using ChatSignalR.Mongo;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChatSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChatRepository _repo;

        public HomeController(ILogger<HomeController> logger, IChatRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index(string userName = "Frank Benício")
        {
            ViewData["UserName"] = userName;

            var chat = await _repo.GetAllChats();

            return View(chat);
        }

        public IActionResult UserName()
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