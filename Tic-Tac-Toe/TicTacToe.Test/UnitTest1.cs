using System;
using Xunit;
using TicTacToeGame;

namespace TicTacToeGame.Test
{
    public class UnitTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var game = new TicTacToe();
            Assert.Equal(0, game.TurnCount);
            // Check to make sure all 9 squares are empty
            bool allEmpty = true;
            for (int r = 0; r < TicTacToe.ROWS; r++)
                for (int c = 0; c < TicTacToe.COLS; c++)
                    if (game.GetMark(r, c) !== ' ')
                        allEmpty = false;
            Assert.True(allEmpty);
        }
    }
}

/*
    Facts are tests which are always true. They test invariant conditions.
    Theories are tests which are only true for a particular set of data.
*/