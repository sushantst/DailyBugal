using BugalDaily.Models;
using BugalDaily.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugalDaily.Controllers
{
    public class TechnologyController : Controller
    {
        private readonly TechnologyService _techService = new();
        private static List<TechArticleModel> _cachedArticles = new();

        public async Task<IActionResult> Index()
        {
            var articles = await _techService.GetTechnologyNewsAsync();
            _cachedArticles = articles;
            return View("~/Views/Main/TechnologyView.cshtml", articles);
        }

        public IActionResult Details(string url)
        {
            var article = _cachedArticles.FirstOrDefault(a => a.Url == url);
            if (article == null)
                return NotFound();

            return View("~/Views/Main/TechDetailView.cshtml", article);
        }

        public async Task<IActionResult> Sports()
        {
            var articles = await _techService.GetSportsNewsAsync();
            _cachedArticles = articles;
            return View("~/Views/Sports/SportsView.cshtml", articles);
        }

        public IActionResult SportsDetails(string encodedUrl)
        {
            if (string.IsNullOrEmpty(encodedUrl))
                return NotFound("Missing URL");

            string decodedUrl = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUrl));
            var article = _cachedArticles.FirstOrDefault(a => a.Url == decodedUrl);

            if (article == null)
                return NotFound("Article not found");

            return View("~/Views/Sports/SportsDetailsView.cshtml", article);
        }

        public async Task<IActionResult> Astrology()
        {
            var articles = await _techService.GetAstrologyNewsAsync();
            _cachedArticles = articles;
            return View("~/Views/Astrology/AstrologyView.cshtml", articles);
        }

        public IActionResult AstrologyDetails(string encodedUrl)
        {
            if (string.IsNullOrEmpty(encodedUrl))
                return NotFound("Missing URL");

            string decodedUrl = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUrl));
            var article = _cachedArticles.FirstOrDefault(a => a.Url == decodedUrl);

            if (article == null)
                return NotFound("Article not found");

            return View("~/Views/Astrology/AstrologyDetailsView.cshtml", article);
        }
    }
}
