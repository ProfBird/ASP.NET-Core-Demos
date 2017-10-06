using System;
using Xunit;
using TicTacToeGame;

namespace TicTacToe.Test
{
    public class UnitTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var game = new TicTacToe();
        }
    }
}
