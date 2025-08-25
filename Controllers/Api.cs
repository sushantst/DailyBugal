using BugalDaily.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugalDaily.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReportingApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReportingApiController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("ReportNewArticle")]
        public async Task<IActionResult> ReportNewArticle([FromForm] ReportNewArticleDto dto)
        {
            string? imagePath = null;

            if (dto.ArticleImage != null && dto.ArticleImage.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, dto.ArticleImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.ArticleImage.CopyToAsync(stream);
                }

                imagePath = "/uploads/" + dto.ArticleImage.FileName; 
            }

            else
            {
                
            }
            // Save article to DB
            var article = new ReportedArticle
            {
                Title = dto.Title,
                Author = dto.Author,
                Location = dto.Location,
                Country = dto.Country,
                Article = dto.Article,
                ImagePath = imagePath 
            };

            _context.ReportedArticles.Add(article);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Article saved successfully!", articleId = article.Id });
        }

    }
}
