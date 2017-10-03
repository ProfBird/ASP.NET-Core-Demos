using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebPages3Tutorial.Pages
{
    public class MathQuizModel : PageModel
    {
        Random random = new Random();
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Result { get; set; }
        public void OnGet()
        {
            Number1 = random.Next(0, 101).ToString();
            Number2 = random.Next(0, 101).ToString();
        }

        public IActionResult OnPost()
        {
            int answer = int.Parse(Request.Form["Answer"]);
            int number1 = int.Parse(Request.Form["number1"]);
            int number2 = int.Parse(Request.Form["number2"]);

            if (answer == number1 + number2)
                Result = "Gold star for you!";
            else
                Result = "Sorry!";
            return Page();
        }
    }
}