using System;
using System.Collections.Generic;
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

        private static void CheckThereIsAtLeastOneActiveCellToBeginWith(List<string> input)
        {
            if (input.All(row => row.All(character => char.ToLower(character) != 'x')))
            {
                throw new ArgumentException("Your grid should have at least one live cell for the initial state");
            }
        }

        private static void CheckAllRowsHaveSameAmountOfColumns(List<string> input)
        {
            if (input.Any(row => row.Length != input[0].Length))
            {
                throw new ArgumentException("Your grid should have the same width for all rows");
            }
        }

        private static void CheckOnlyPeriodsAndXCharactersAreUsed(List<string> input)
        {
            if (input.Any(row => row.Any(character => char.ToLower(character) != 'x' && character != '.')))
            {
                throw new ArgumentException("You can only use x and . characters in your input");
            }        
        }

    }
}