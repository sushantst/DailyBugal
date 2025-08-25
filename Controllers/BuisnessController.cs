using BugalDaily.Models;
using BugalDaily.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BugalDaily.Controllers
{
    public class BuisnessController : Controller
    {
       
        private readonly TechnologyService _techService = new();
        private static List<TechArticleModel> _cachedArticles = new();

        public async Task<IActionResult> Index()
        {
            var articles = await _techService.GetBuisnessNewsAsync();
            _cachedArticles = articles;
            return View("~/Views/Buisness/BuisnessView.cshtml", articles);
        }

        public IActionResult Details(string url)
        {
            var article = _cachedArticles.FirstOrDefault(a => a.Url == url);
            if (article == null)
                return NotFound();

            return View("~/Views/Buisness/BuisnessDetailsView.cshtml", article);
        }
    }
}
