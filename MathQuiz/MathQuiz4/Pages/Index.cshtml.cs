using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MathQuiz4;

namespace MathQuiz4.Pages
{
    public class MathQuizModel : PageModel
    {
        public string Result { get; set; }  // called after OnGet, or after OnPost

        [BindProperty]
        public MathQuiz Quiz { get; set; } // get is called before OnPost. Watch out!


        const string RAND_NUMBER_1 = "RandNumber1";
        const string RAND_NUMBER_2 = "RandNumber2";

        // This gets called first
        public void OnGet()
        {
            Quiz = new MathQuiz();
            HttpContext.Session.SetInt32(RAND_NUMBER_1, Quiz.Number1);
			HttpContext.Session.SetInt32(RAND_NUMBER_2, Quiz.Number2);
		}

        // Called when the submit button is clicked
        public IActionResult OnPost()
        {
            // The Quiz object was already created automatically because
            // MathQuiz is a bound property
            Quiz.Number1 = HttpContext.Session.GetInt32(RAND_NUMBER_1) ?? 0;
            Quiz.Number2 = HttpContext.Session.GetInt32(RAND_NUMBER_2) ?? 0;
            Result = Quiz.CheckAnswer();

            return Page();
        }
    }
}