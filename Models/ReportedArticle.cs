namespace BugalDaily.Models
{
    public class ReportedArticle
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Article { get; set; }
        public string? ImagePath { get; set; } // Store file path (not actual image)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
