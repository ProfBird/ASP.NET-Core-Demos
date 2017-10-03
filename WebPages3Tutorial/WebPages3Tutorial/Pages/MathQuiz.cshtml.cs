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
            Number1 = Request.Form["number1"];
            int n1 = int.Parse(Number1);
            Number2 = Request.Form["number2"];
            int n2 = int.Parse(Number2);
			int answer = int.Parse(Request.Form["answer"]);

			if (answer == n1 + n2)
                Result = "A gold star for you!";
            else
                Result = "Sorry! Try again";
            
            return Page();
        }
    }
}