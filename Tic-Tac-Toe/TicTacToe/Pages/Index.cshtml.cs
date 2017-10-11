using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicTacToeGame.Pages
{
    public class TicTacToeModel : PageModel
    {
        TicTacToe game;

        public TicTacToe Game
        {
            get { return game; }
        }

        public string GetImage(int r, int c)
        {
            return "images/" + game.GetMark(r, c) + ".png";
        }

        public void OnGet()
        {
            game = new TicTacToe();
        }

        public IActionResult OnPost(int cell)
        {
            game = new TicTacToe();

            // Get the saved game grid
            byte[] grid = HttpContext.Session.Get("grid");
            if (grid != null)
            {
                game.Grid = grid;
            }

            // Put a new X or O in the tgrid
            int r = cell / 3;
            int c = cell % 3;
            game.SetMark(r, c);

            // Save the game grid
            HttpContext.Session.Set("grid", game.Grid);

            return Page();
        }
    }
}
