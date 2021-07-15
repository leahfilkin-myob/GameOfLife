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

        public static List<string> GetValidInput(string methodOfInput)
        {
            var input = new List<string>();
            while (true)
            {
                try
                {
                    input = UserInterface.HandleInput(methodOfInput);
                    Validate(input);
                    break;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (InvalidOperationException ie)
                {
                    Console.WriteLine(ie.Message);
                    methodOfInput = UserInterface.AskForMethodOfInput().ToUpper();
                }
            }

            return input;
        }

    }
}