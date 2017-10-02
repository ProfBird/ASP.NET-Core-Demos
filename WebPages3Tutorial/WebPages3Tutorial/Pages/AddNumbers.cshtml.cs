using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebPages3Tutorial.Pages
{
    public class AddNumbersModel : PageModel
    {
        public string TotalMessage { get; set; }
        public IActionResult OnPost()
        {
            var total = 0.0;

            // Retrieve the numbers that the user entered.
            var num1 = Request.Form["text1"];
            var num2 = Request.Form["text2"];

            // Convert the entered strings into integers numbers and add.
            total = double.Parse(num1) + double.Parse(num2);
            TotalMessage = "Total = " + total;
            return Page();
        }
    }
}