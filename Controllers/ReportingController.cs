using Microsoft.AspNetCore.Mvc;

namespace BugalDaily.Controllers
{
    public class ReportingController : Controller
    {
        public IActionResult ReportNewArticle()
        {
            return View("~/views/ReportNewArticle.cshtml");
        }
    }
}
