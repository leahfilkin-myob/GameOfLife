using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public static class InputValidator
    {
        public static void Validate(List<string> input)
        {
            CheckOnlyPeriodsAndXCharactersAreUsed(input);
            CheckAllRowsHaveSameAmountOfColumns(input);
            CheckThereIsAtLeastOneActiveCellToBeginWith(input);
        }
        
        public static void Validate(string userMethodOfInput)
        {
            if (userMethodOfInput != "C" && userMethodOfInput != "F")
            {
                throw new InvalidOperationException(
                    "You can only enter F for file or C for console for your method of input");
            }
        }
        private static void CheckThereIsAtLeastOneActiveCellToBeginWith(List<string> input)
        {
            if (input.All(row => row.All(character => char.ToLower(character) != 'x')))
            {
                throw new ArgumentException("Your grid should have at least one live cell for the initial state. Please enter a new input.");
            }
        }

        private static void CheckAllRowsHaveSameAmountOfColumns(List<string> input)
        {
            if (input.Any(row => row.Length != input[0].Length))
            {
                throw new ArgumentException("Your grid should have the same width for all rows. Please enter a new input.");
            }
        }

        private static void CheckOnlyPeriodsAndXCharactersAreUsed(List<string> input)
        {
            if (input.Any(row => row.Any(character => char.ToLower(character) != 'x' && character != '.')))
            {
                throw new ArgumentException("You can only use x and . characters in your input. Please enter a new input.");
            }        
        }
    }
}