namespace BugalDaily.Models
{
    
    public static class ReviewStore
    {
        public static List<Review> Reviews { get; set; } = new List<Review>();
    }

    public class Review
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
