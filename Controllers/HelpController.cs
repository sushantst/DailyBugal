using Microsoft.AspNetCore.Mvc;

namespace BugalDaily.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Helpus()
        {
            return View();
        }

        public IActionResult AdBooking()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
