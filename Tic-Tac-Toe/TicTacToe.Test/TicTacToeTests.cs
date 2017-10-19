using Xunit;

namespace TicTacToeGame.Test
{
    public class TicTacToeTests
    {
        TicTacToe game;

        // A new UnitTest object is created for each
        // test, so each test gets a new game object
        public TicTacToeTests()
        {
            game = new TicTacToe();
        }


        [Fact]
        public void ConstructorTest()
        {
            bool allEmpty = true;
            for (int r = 0; r < TicTacToe.ROWS; r++)
                for (int c = 0; c < TicTacToe.COLS; c++)
                    if (game.GetMark(r, c) != "blank")
                        allEmpty = false;
            
            // Verify that the game grid array is empty
            Assert.True(allEmpty);
        }


        [Fact]
        public void TurnCountTest()
        {
            Row0X();    // Make 5 moves
            Assert.Equal(5, game.TurnCount);
        }



        [Fact]
		public void GetTurnXTest()
		{
			Row1O();    // Make 6 moves
            Assert.Equal('X', game.GetTurn());
		}

        [Fact]
		public void GetTurnOTest()
        {
            Row0X();    // Make 5 moves
            Assert.Equal('O', game.GetTurn());
        }

<<<<<<< Updated upstream
        [Fact]
        public void GridTest()
        {
            game.Grid[0] = (byte)'X';
            Assert.Equal(game.GetMark(0,0), "X");
        }

        /*
=======

        // Test all the possible winning combinations for X
>>>>>>> Stashed changes
        [Theory]
        [InlineData(0, 0, 0, 1, 0, 2)] // row 1
        [InlineData(1, 0, 1, 1, 1, 2)] // row 2
        [InlineData(0, 0, 1, 1, 2, 2)] // row 3
        [InlineData(0, 0, 1, 0, 2, 0)] // col 1
        [InlineData(0, 1, 1, 1, 2, 1)] // col 2
        [InlineData(0, 2, 1, 2, 2, 2)] // col 3
        [InlineData(0, 0, 1, 1, 2, 2)] // diagonal 1
        [InlineData(0, 2, 1, 1, 2, 0)] // diagonal 2
        public void CheckForXWinTest(int r1, int c1, int r2, int c2, int r3, int c3)
        {
            game.Grid[RowColToIndex(r1, c1)] = (byte)'X';
            game.Grid[RowColToIndex(r2, c2)] = (byte)'X';
            game.Grid[RowColToIndex(r3, c3)] = (byte)'X';

            Assert.Equal('X', game.CheckForWinner());
        }
*/

        //********* Private methods *************

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

        // Convert row and column for a 2D array to an index for a 1D array
        private int RowColToIndex(int r, int c)
        {
            return r * TicTacToe.ROWS + c;
        }
       
	}
}

/*
    Facts are tests which are always true. They test invariant conditions.
    Theories are tests which are only true for a particular set of data.
*/