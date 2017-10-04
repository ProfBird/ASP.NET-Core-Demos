using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MathQuiz2.Pages
{
    public class MathQuizModel : PageModel
    {
        Random random = new Random();
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string Result { get; set; }

        const string RAND_NUMBER_1 = "RandNumber1";
        const string RAND_NUMBER_2 = "RandNumber2";

        public void OnGet()
        {
            Number1 = random.Next(0, 101);
            HttpContext.Session.SetInt32(RAND_NUMBER_1, Number1);
			Number2 = random.Next(0, 101);
			HttpContext.Session.SetInt32(RAND_NUMBER_2, Number2);
		}

        public IActionResult OnPost()
        {
            
            Number1 = (int)HttpContext.Session.GetInt32(RAND_NUMBER_1);
            Number2 = (int)HttpContext.Session.GetInt32(RAND_NUMBER_2);
            string answer = Request.Form["answer"];
            int answerInt;
            if (int.TryParse(answer, out answerInt))
            {
                if (answerInt == Number1 + Number2)
                    Result = "A gold star for you!";
                else
                    Result = "Sorry! Try again";
            }
            else
            {
                Result = "Please enter a valid integer";
            }

            return Page();
        }
    }
}