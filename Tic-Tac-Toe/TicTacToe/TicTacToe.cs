using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeGame
{
    /// <summary>
    /// This is the game-play logic for the tic-tac-toe game
    /// </summary>
    public class TicTacToe
    {
        private char[,] gameGrid;   // represents the tic-tac-toe playing grid
        public const int ROWS = 3;
        public const int COLS = 3;
        private int xCount, oCount; // number of Os and Xs currently on the grid

        public byte[] Grid { 
            get {
                byte[] byteGrid = new byte[ROWS * COLS];
                for (int r = 0; r < ROWS; r++)
                    for (int c = 0; c < COLS; c++)
                        byteGrid[r * ROWS + c] = (byte)gameGrid[r, c];
                return byteGrid;
                } 

            set {
                for (int r = 0; r < ROWS; r++)
                    for (int c = 0; c < COLS; c++)
                        gameGrid[r, c] = (char)value[r * ROWS + c];
            }
        }

        // This constructor uses an initialization list to set all the elements
        // of the gameGrid array to spaces.
        public TicTacToe()
        {
            gameGrid = new char[ROWS, COLS] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            xCount = 0;
            oCount = 0;
        }


        // Counts the number of ones and zeros
        // (used by methods that determine the number of turns and whose turn it is)
        private void UpdateXOCount()
        {
            xCount = 0;
            oCount = 0;
            for (int r = 0; r < ROWS; r++)
                for (int c = 0; c < COLS; c++)
                    if (gameGrid[r, c] == 'X')
                        xCount++;
                    else if (gameGrid[r, c] == 'O')
                        oCount++;
        }

        // The number of turns taken 
        public int TurnCount
        {
            get
            {
                UpdateXOCount();
                return xCount + oCount;
            }
        }

        // See if it's X's turn or O's
        // first turn is always X
        public char GetTurn()
        {
            UpdateXOCount();
            if (xCount > oCount)
                return 'O';
            else
                return 'X';
        }

        // Add a mark (either X or O depending on turn) to the grid
        // Returns false if there was already a mark there
        public bool SetMark(int row, int col)
        {
            if (gameGrid[row, col] != ' ' || CheckForWinner() != ' ')
                return false;

            if (GetTurn() == 'X')
                gameGrid[row, col] = 'X';
            else
                gameGrid[row, col] = 'O';
            return true;
        }

        public string GetMark(int r, int c)
        {
            string mark = gameGrid[r, c].ToString();

            if (mark == " ")
            {
                mark = "blank";
            }

            return mark;
        }

        public char CheckForWinner()
        {
            // We only need to check the cells in the middle row and column
            // For each cell, see if there are two marks of the same kind adjacent to it.
            char winner = ' ';

            // Go across the middle row, row 1, checking for a winner
            // These would be vertical columns of Os or Xs
            for (int c = 0; c < COLS; c++)
                if (gameGrid[1, c] != ' ' && gameGrid[1, c] == gameGrid[0, c] && gameGrid[1, c] == gameGrid[2, c])
                    winner = gameGrid[1, c];

            if (winner == ' ')          // ' ' means no winner found yet
            {
                // Go down the middle column checking for a winner
                // These would be horizontal rows of Os or Xs
                for (int r = 0; r < ROWS; r++)
                    if (gameGrid[r, 1] != ' ' && gameGrid[r, 1] == gameGrid[r, 0] && gameGrid[r, 1] == gameGrid[r, 2])
                        winner = gameGrid[r, 1];
            }

            if (winner == ' ')          // ' ' means no winner found yet
            {
                // Check the two diagonals
                if (gameGrid[1, 1] != ' ' &&
                    ((gameGrid[1, 1] == gameGrid[0, 0] && gameGrid[1, 1] == gameGrid[2, 2]) ||
                    (gameGrid[1, 1] == gameGrid[0, 2] && gameGrid[1, 1] == gameGrid[2, 0]))
                    )
                    winner = gameGrid[1, 1];
            }
            return winner;
        }
    }
}

