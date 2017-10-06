using System;
namespace MathQuiz3
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

		// **** Constructors ****

		public MathQuiz()                   // use this constructor in OnGet 
		{                                   // to generate random numbers
			Random random = new Random();
			number1 = random.Next(0, 101);  // generate numbers from 0 to 100
			number2 = random.Next(0, 101);
		}

		public MathQuiz(int n1, int n2)     // use this constructor in OnPost 
		{                                   // when retrieving stored random numbers
 			number1 = n1;
			number2 = n2;
		}

		// **** Methods ****

		public string CheckAnswer(int answer)
        {
            string result;
			if (answer == number1 + number2)
				result = "A gold star for you!";
			else
				result = "Sorry! Try again";
            return result;
        }
    }
}
