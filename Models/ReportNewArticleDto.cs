using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BugalDaily.Models
{
    public class ReportNewArticleDto
    {
        [Required] public string Title { get; set; }
        [Required] public string Author { get; set; }
        public string? Location { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string Article { get; set; }

        [BindProperty]
        public IFormFile? ArticleImage { get; set; }
    }
}
