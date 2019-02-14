using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Library
{
    public static class CrashElementsHelper
    {
        private static bool IsNumberBetweenRangeOfNumbers(int number, int rangeStart, int rangeEnd)
        {
            bool NumberBetweenRangeOfNumbers = number >= rangeStart && number <= rangeEnd;
            return NumberBetweenRangeOfNumbers;
        }


        public static bool IsTwoNumberBetweenRangeOfTowNumbers(int number1, int number2, int rangeStart, int rangeEnd)
        {
            bool number1BetweenRangeOfNumbers = IsNumberBetweenRangeOfNumbers(number1, rangeStart, rangeEnd);

            bool number2BetweenRangeOfNumbers = IsNumberBetweenRangeOfNumbers(number2, rangeStart, rangeEnd);

            bool TwoNumberBetweenRangeOfTowNumbers = number1BetweenRangeOfNumbers || number2BetweenRangeOfNumbers;

            return TwoNumberBetweenRangeOfTowNumbers;
        }

    }
}
