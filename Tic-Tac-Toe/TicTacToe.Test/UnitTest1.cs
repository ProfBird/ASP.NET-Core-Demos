using System;
using Xunit;
using TicTacToeGame;

namespace TicTacToeGame.Test
{
    public class UnitTest
    {
        TicTacToe game;

        // A new UnitTest object is created for each
        // test, so each test gets a new game object
        public UnitTest()
        {
            game = new TicTacToe();
        }


        [Fact]
        public void ConstructorTest()
        {
            bool allEmpty = true;
            for (int r = 0; r < TicTacToe.ROWS; r++)
                for (int c = 0; c < TicTacToe.COLS; c++)
                    if (game.GetMark(r, c) != ' ')
                        allEmpty = false;
            
            Assert.True(allEmpty);
        }

        [Fact]
        public void TurnCountTest()
        {
            Row0X();
            Assert.Equal(game.TurnCount, 5);
        }

        [Fact]
		public void TestGetTurnX()
		{
			Row1O();
			Assert.Equal(game.GetTurn(), 'X');
		}

        [Fact]
		public void TestGetTurnO()
        {
            Row0X();
            Assert.Equal(game.GetTurn(), 'O');
        }

        private void Row0X()
        {
			game.SetMark(0, 0); //X
			game.SetMark(1, 0); //O
			game.SetMark(0, 1); //X
			game.SetMark(1, 1); //O
			game.SetMark(0, 2); //X
		}

        private void Row1O()
        {
			game.SetMark(0, 0); //X
			game.SetMark(1, 0); //O
			game.SetMark(2, 1); //X
			game.SetMark(1, 1); //O
			game.SetMark(0, 2); //X
			game.SetMark(1, 2); //O

		}
	}
}

/*
    Facts are tests which are always true. They test invariant conditions.
    Theories are tests which are only true for a particular set of data.
*/