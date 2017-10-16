using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RomanNumerals.Pages
{
    public class IndexModel : PageModel
    {
        public string Output { get; set; }

        public IActionResult OnPostRoman()
        {
            // testing
            Output = "Roman numeral";
            return Page();
        }

        public IActionResult OnPostDecimal()
        {
            // testing
            Output = "Decimal number";

            return Page();
        }
    }
}

