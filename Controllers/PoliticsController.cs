using BugalDaily.Models;
using BugalDaily.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BugalDaily.Controllers
{
    public class PoliticsController : Controller
    {
        private readonly TechnologyService _politicsService = new();
        private static List<TechArticleModel> _cachedArticles = new();

        public async Task<IActionResult> Index()
        {
            var articles = await _politicsService.GetPoliticsNewsAsync();
            _cachedArticles = articles;
            return View("~/Views/Politics/PoliticsView.cshtml", articles);
        }

        public IActionResult Details(string encodedUrl)
        {
            if (string.IsNullOrEmpty(encodedUrl))
                return NotFound("Missing URL");

            string decodedUrl = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUrl));
            var article = _cachedArticles.FirstOrDefault(a => a.Url == decodedUrl);

            if (article == null)
                return NotFound("Article not found");

            return View("~/Views/Politics/PoliticsDetailsView.cshtml", article);
        }
    }
}
