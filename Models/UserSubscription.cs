namespace BugalDaily.Models
{
    public class UserSubscription
    {
        public int Id { get; set; }
        public string UserId { get; set; } // FK from AspNetUsers
        public int PlanId { get; set; } // FK to SubscriptionPlan
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentId { get; set; } // Razorpay payment ref
        public bool IsActive { get; set; }
    }
}
