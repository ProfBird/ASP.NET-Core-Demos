using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RomanLogic;

namespace RomanNumerals.Pages
{
    public class IndexModel : PageModel
    {
        RomanConversion romanLogic = new RomanConversion();

        [BindProperty]
        public string Input { get; set; }
        public string Output { get; set; }

        public IActionResult OnPostRoman()
        {
            int decimalNumber = int.Parse(Input);
            Output = romanLogic.ToRoman(decimalNumber);
            return Page();
        }

        public IActionResult OnPostDecimal()
        {
            //   string romanNumeral = Input;
            Output = romanLogic.ToDecimal(Input).ToString();
            return Page();
        }
    }
}

