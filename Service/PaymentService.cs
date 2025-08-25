using Razorpay.Api;

namespace BugalDaily.Service
{
    public class PaymentService
    {
        private readonly string _keyId;
        private readonly string _keySecret;

        public PaymentService(IConfiguration configuration)
        {
            _keyId = configuration["Razorpay:KeyId"];
            _keySecret = configuration["Razorpay:KeySecret"];
        }

        public void CreateOrder()
        {
            RazorpayClient client = new RazorpayClient(_keyId, _keySecret);

            Dictionary<string, object> options = new Dictionary<string, object>
        {
            { "amount", 50000 }, // Amount in paise (₹500)
            { "currency", "INR" },
            { "receipt", "order_rcptid_11" }
        };

            Order order = client.Order.Create(options);
            Console.WriteLine("Order ID: " + order["id"]);
        }
    }
}
