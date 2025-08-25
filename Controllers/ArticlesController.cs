using BugalDaily.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BugalDaily.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("NewArticles")]
        public IActionResult NewArticles()
        {
            var articles = _context.ReportedArticles
                                   .OrderByDescending(a => a.CreatedAt)
                                   .ToList();

            return View("~/Views/NewArticles.cshtml", articles);
        }


    }
}
