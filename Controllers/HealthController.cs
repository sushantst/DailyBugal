using BugalDaily.Models;
using BugalDaily.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BugalDaily.Controllers
{
    public class HealthController : Controller
    {
        private readonly TechnologyService _politicsService = new();
        private static List<TechArticleModel> _cachedArticles = new();

        public async Task<IActionResult> Index()
        {
            var articles = await _politicsService.GetBuisnessNewsAsync();
            _cachedArticles = articles;
            return View("~/Views/Health/HealthView.cshtml", articles);
        }

        public IActionResult Details(string url)
        {
            var article = _cachedArticles.FirstOrDefault(a => a.Url == url);
            if (article == null)
                return NotFound();

            return View("~/Views/Health/HealthDetailsView.cshtml", article);
        }
    }
}
