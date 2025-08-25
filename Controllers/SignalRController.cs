using Microsoft.AspNetCore.Mvc;

namespace BugalDaily.Controllers
{
    [Route("signal")]
    public class SignalRController:Controller
    {
        public IActionResult SignalR()
        {
            return View();
        }
    }
}
