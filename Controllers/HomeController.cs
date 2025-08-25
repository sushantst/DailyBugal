using BugalDaily.Models;
using BugalDaily.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BugalDaily.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TechnologyService _techService = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var articles = await _techService.GetTechnologyNewsAsync();
            var general = await _techService.GetGeneralNewsAsync();
            var sports = await _techService.GetInSportsNewsAsync();
            var buisness = await _techService.GetBuisnessNewsAsync();
            var education = await _techService.GetInEducationNewsAsync();
            var viewModel = new MultipleNewsSourceModel
            {
                articles = articles,
                general = general,
                sports = sports,
                buisness = buisness
            };
            return View(viewModel); 
        }
        public IActionResult Main()
        {
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
