using System;

namespace RomanLogic
{
    public class RomanConversion
    {
        string[] roman = {"I","II","III", "IV",
            "V", "VI", "VII", "VIII", "IX", "X" };

        // Convert a roman numeral to integer
        public int ToDecimal(string romanNumeral)
        {
            return Array.IndexOf(roman, romanNumeral) + 1;
        }

        // Convert an integer number to a roman numeral
        public string ToRoman(int decimalNumber)
        {
            return roman[decimalNumber - 1];
        }
    }
}
