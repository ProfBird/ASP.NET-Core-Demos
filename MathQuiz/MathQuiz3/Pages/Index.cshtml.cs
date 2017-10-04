using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MathQuiz3;

namespace MathQuiz3.Pages
{
    public class MathQuizModel : PageModel
    {
        MathQuiz quiz;
        public int Number1 { get { return quiz.Number1; } }
        public int Number2 { get { return quiz.Number2; } }
        public string Result { get; set; }

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

            string answerString = Request.Form["answer"];
            int answer;
            if (int.TryParse(answerString, out answer))
            {
                Result = quiz.CheckAnswer(answer);
            }
            else
            {
                Result = "Please enter a valid integer";
            }

            return Page();
        }
    }
}