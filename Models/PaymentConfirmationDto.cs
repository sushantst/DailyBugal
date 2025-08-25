using System.Text.Json.Serialization;

namespace BugalDaily.Models
{
    public class PaymentConfirmationDto
    {
        [JsonPropertyName("razorpay_payment_id")]
        public string RazorpayPaymentId { get; set; }

        [JsonPropertyName("razorpay_order_id")]
        public string RazorpayOrderId { get; set; }

        [JsonPropertyName("razorpay_signature")]
        public string RazorpaySignature { get; set; }

        public int PlanId { get; set; } 
    }
}
