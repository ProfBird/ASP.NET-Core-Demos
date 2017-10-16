using System;
using Xunit;
using RomanLogic;

namespace RomanTest
{
    public class RomanConversionTests
    {
        [Fact]
        public void DecimalToRoman()
        {
            // Arrange
            var convert = new RomanConversion();

            // Apply
            string roman = convert.ToRoman(4);

            // Assert
            Assert.Equal("IV", roman);
        }

        [Fact]
        public void RomanToDecimal()
        {
            // Arrange
            var convert = new RomanConversion();

            // Apply
            int decimalNumber = convert.ToDecimal("IV");


            // Assert
            Assert.Equal(4, decimalNumber);
        }
    }
}
