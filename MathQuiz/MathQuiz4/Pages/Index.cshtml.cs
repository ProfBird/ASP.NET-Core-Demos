using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MathQuiz4;

namespace MathQuiz4.Pages
{
    public class MathQuizModel : PageModel
    {
        MathQuiz quiz = null;
        public string Result { get; set; }

        [BindProperty]
        public MathQuiz Quiz 
        { 
            get { return quiz; } 
        }

        const string RAND_NUMBER_1 = "RandNumber1";
        const string RAND_NUMBER_2 = "RandNumber2";

        public void OnGet()
        {
            quiz = new MathQuiz();
            HttpContext.Session.SetInt32(RAND_NUMBER_1, quiz.Number1);
			HttpContext.Session.SetInt32(RAND_NUMBER_2, quiz.Number2);
		}

        public IActionResult OnPost()
        {
            quiz = new MathQuiz(
                (int)HttpContext.Session.GetInt32(RAND_NUMBER_1),
                (int)HttpContext.Session.GetInt32(RAND_NUMBER_2)
            );

            Result = quiz.CheckAnswer();

            return Page();
        }
    }
}