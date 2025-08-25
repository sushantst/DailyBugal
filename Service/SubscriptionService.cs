using BugalDaily.Models;

namespace BugalDaily.Service
{
    public class SubscriptionService
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool HasActiveSubscription(string userId)
        {
            return _context.UserSubscriptions
                .Any(s => s.UserId == userId && s.IsActive && s.EndDate >= DateTime.Now);
        }
    }
}
