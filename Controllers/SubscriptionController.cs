using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using BugalDaily.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace BugalDaily.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public SubscriptionController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        // ✅ Creates Razorpay order
        [HttpPost]
        public IActionResult CreateOrder(int planId)
        {
            var plan = _context.SubscriptionPlans.Find(planId);
            if (plan == null) return NotFound();

            var keyId = _config["Razorpay:KeyId"];
            var keySecret = _config["Razorpay:KeySecret"];

            var client = new RazorpayClient(keyId, keySecret);

            var options = new Dictionary<string, object>
            {
                { "amount", plan.Price * 100 }, // amount in paise
                { "currency", "INR" },
                { "receipt", Guid.NewGuid().ToString() },
                { "payment_capture", 0 }, // auto capture
                { "notes", new Dictionary<string, string>
                    {
                        { "UserId", _userManager.GetUserId(User) },
                        { "PlanId", plan.Id.ToString() }
                    }
                }
            };

            Order order = client.Order.Create(options);

            return Json(new
            {
                orderId = order["id"].ToString(),
                amount = plan.Price,
                key = keyId,
                planId = plan.Id
            });
        }

        // ✅ Confirm payment from frontend
        [HttpPost]
        public IActionResult ConfirmPayment([FromBody] PaymentConfirmationDto dto)
        {
            var keySecret = _config["Razorpay:KeySecret"];

            // 🔐 Verify signature
            string generatedSignature = GenerateSignature(dto.RazorpayOrderId + "|" + dto.RazorpayPaymentId, keySecret);

            if (generatedSignature != dto.RazorpaySignature)
            {
                return BadRequest(new { success = false, message = "Payment verification failed" });
            }

            var plan = _context.SubscriptionPlans.Find(dto.PlanId);
            if (plan == null) return NotFound();

            var subscription = new UserSubscription
            {
                UserId = _userManager.GetUserId(User),
                PlanId = plan.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(plan.DurationInDays),
                PaymentId = dto.RazorpayPaymentId,  
                IsActive = true
            };

            _context.UserSubscriptions.Add(subscription);
            _context.SaveChanges();

            return Ok(new { success = true });
        }

        // ✅ Load plans and pass Razorpay key to view
        public IActionResult Plans()
        {
            var plans = _context.SubscriptionPlans.ToList();
            ViewBag.RazorpayKey = _config["Razorpay:KeyId"];
            return View(plans);
        }

        // 🔐 Helper to verify signature
        private string GenerateSignature(string data, string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var dataBytes = Encoding.UTF8.GetBytes(data);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                var hash = hmac.ComputeHash(dataBytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }

   

    public class PaymentConfirmationDto
    {
        public string RazorpayPaymentId { get; set; }
        public string RazorpayOrderId { get; set; }
        public string RazorpaySignature { get; set; }
        public int PlanId { get; set; }
    }
}
