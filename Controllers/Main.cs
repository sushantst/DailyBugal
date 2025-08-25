using Microsoft.AspNetCore.Mvc;

namespace BugalDaily.Controllers
{
    public class Main : Controller
    {
        public IActionResult MainView()
        {
            return View();
        }
    }
}
