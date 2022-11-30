using Microsoft.AspNetCore.Mvc;
using MVCVideoGameRepository.Models;
using System.Diagnostics;

namespace MVCVideoGameRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Games(string game = "")
        {
            if(string.IsNullOrEmpty(game))
            {
                return View(new VideoGameRepository().VideoGames);
            } else
            {
                return View(new VideoGameRepository().VideoGames.Where(g => g.Title == game).ToHashSet());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}