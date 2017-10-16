using MathQuiz4;
using Xunit;

namespace MathQuiz4.Tests
{
    public class MathTests
    {
        MathQuiz math;
        const int NUMBER1 = 100;
        const int NUMBER2 = 52;
 
        public MathTests()
        {
            // Arrange
            math = new MathQuiz();
            math.Number1 = NUMBER1;
            math.Number2 = NUMBER2;
         }

        [Fact]
        public void DefaultConstructorTest()
        {
            // Arrange - Nothing to do
            // Apply - Nothing to do
            // Assert - Just make sure that we have an object and numbers
            Assert.True(math.Number1 >= 0 && math.Number2 >= 0);
        }

        [Fact]
        public void CorrectResultTest()
        {
            // Apply
            math.Answer = NUMBER1 + NUMBER2;
            // Assert
            Assert.True(math.Result == "A gold star for you!");
        }

        [Fact]
        public void IncorrectResultTest()
        {
            // Apply
            math.Answer = NUMBER1;
            // Assert
            Assert.True(math.Result == "Sorry! Try again");
        }

        [Fact]
        public void NoAnswerResultTest()
        {
            // Apply
            math.Answer = null;
            // Assert
            Assert.True(math.Result == "");
        }


   }
}
