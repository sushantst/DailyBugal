using BugalDaily.Service;
using Microsoft.AspNetCore.Mvc;

namespace BugalDaily.Controllers
{
    public class UploadController : Controller
    {
        private readonly BlobStorageService _blobService;

        public UploadController(BlobStorageService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Please select a file.";
                return View();
            }

            var url = await _blobService.UploadAsync(file);
            ViewBag.ImageUrl = url;

            return View();
        }
    }
}


