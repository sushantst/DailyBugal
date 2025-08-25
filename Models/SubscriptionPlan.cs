using Microsoft.EntityFrameworkCore;

namespace BugalDaily.Models
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } // "1 User / 1 Year"

        [Precision(18, 2)]
        public decimal Price { get; set; }// 100, 500, 1000
        public int DurationInDays { get; set; } // 365
        public int MaxUsers { get; set; } // 1, 5, 10
    }
}
