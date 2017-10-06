using System;
using System.ComponentModel.DataAnnotations;

namespace MathQuiz4
{
    public class MathQuiz
    {
        // **** Properties ****

        int number1;
        public int Number1 
        {
            get { return number1; }
            set { number1 = value; }
        }

        int number2;
        public int Number2 
        {
            get { return number2; } 
            set { number2 = value; } 
        }

        public string Result 
        {
            get { return CheckAnswer(); }
        }

		int? answer = null;     // Initially null so nothing is displayed after a HTTP GET
        [Required]              // Validation rulse
        [Range(0, 200)]
        public int? Answer { 
            get { return answer; }
            set { answer = value; }
        }

        // **** Constructors ****

        public MathQuiz()                   // use this constructor in OnGet 
		{                                   // to generate random numbers
			Random random = new Random();   
			number1 = random.Next(0, 101);  // generate numbers from 0 to 100
			number2 = random.Next(0, 101);
		}

        public MathQuiz(int n1, int n2)     // use this constructor in OnPost 
        {                                   // to retrieve stored random numbers
			number1 = n1;
			number2 = n2;
		}

        // **** Methods ****

        private string CheckAnswer()
        {
            string result;
            if (answer == null)  // this means no answer has been set
                result = "";
            else if (answer == number1 + number2)
                result = "A gold star for you!";
            else
                result = "Sorry! Try again";

            return result;
        }
    }
}
