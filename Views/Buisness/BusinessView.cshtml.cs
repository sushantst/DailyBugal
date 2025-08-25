using BugalDaily.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


    namespace BugalDaily.Views.Business
    {
        public class BusinessViewModel : PageModel
        {
            [BindProperty]
            public string Message { get; set; }

            public List<Review> AllReviews => ReviewStore.Reviews;

            public void OnGet()
            {
                // This method runs on page load (GET)
            }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Message))
            {
                ReviewStore.Reviews.Add(new Review
                {
                    UserName = "Anonymous", // or bind another property for username
                    Comment = Message,
                    TimeStamp = DateTime.Now
                });
            }

            return RedirectToPage(); // reloads and shows the updated list
        }

    }
}


