using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicTacToeGame.Pages
{
    public class TicTacToeModel : PageModel
    {
        TicTacToe game;
        const string GRID = "grid";

        public TicTacToe Game
        {
            get { return game; }
        }

        // Get an image of an X, O or blank
        public string GetImage(int r, int c)
        {
            return "images/" + game.GetMark(r, c) + ".png";
        }

        // Determines whether X or O won
        public string GetWinner()
        {
            string message = "";
            char winner = game.CheckForWinner();
            if(winner != ' ')
            {
                message = winner + " is the winner!";
            }
            return message;
        }

        // This is only called when the game is first started
        public void OnGet()
        {
            // We need a game object, becausde the Razor page always 
            // displays what's in the game object's game grid
            game = new TicTacToe();

            // We need to clear out the game grid when we start a new game
            HttpContext.Session.Clear();
        }

        // This method gets the value of the button that was clicked as a parameter
        public IActionResult OnPost(int cell)
        {
            game = new TicTacToe();

            // Get the saved game grid
            byte[] grid = HttpContext.Session.Get(GRID);
            if (grid != null)
            {
                game.Grid = grid;
            }

            // Put a new X or O in the grid
            int r = cell / 3;  // calculates the row
            int c = cell % 3;  // calculates the column
            game.SetMark(r, c);

            // Save the game grid
            HttpContext.Session.Set(GRID, game.Grid);

            return Page();
        }
    }
}
