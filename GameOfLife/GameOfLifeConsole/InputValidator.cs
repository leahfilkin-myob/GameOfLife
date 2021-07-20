using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.GameOfLifeConsole.InputHandlers;
using GameOfLife.GameOfLifeLogic;

namespace GameOfLife.GameOfLifeConsole
{
    public static class InputValidator
    {

        private static List<Point> ConvertXCharactersToLiveCellPoints(List<string> input)
        {
            var indexesAsPoints = input.SelectMany((row, i) => row
                .Select((square, j) => new Point(i, j)));
            return
                indexesAsPoints.Where(point => char.ToLower(input[point.X][point.Y]) == 'x').ToList();
        }

        public static Grid ParseInputToGrid(List<string> input)
        {
            Validate(input);
            return new Grid(input.Count, input[0].Length, ConvertXCharactersToLiveCellPoints(input));
        }

        public static IInputHandler ParseInputChoiceTypeToInputHandler(string userMethodOfInput)
        {
            return userMethodOfInput switch
            {
                "C" => new ConsoleInputHandler(),
                "F" => new FileInputHandler(),
                _ => throw new ArgumentOutOfRangeException(nameof(userMethodOfInput), "\nYou have selected an input type that's not supported.")
            };
        }

        private static void Validate(List<string> input)
        {
            CheckOnlyPeriodsAndXCharactersAreUsed(input);
            CheckAllRowsHaveSameAmountOfColumns(input);
            CheckAtLeastOneLiveCellExists(input);
        }

        private static void CheckAtLeastOneLiveCellExists(List<string> input)
        {
            if (input.All(row => row.All(character => char.ToLower(character) != 'x')))
            {
                throw new ArgumentException("\nYour grid should have at least one live cell for the initial state. Please enter a new input.");
            }
        }

        private static void CheckAllRowsHaveSameAmountOfColumns(List<string> input)
        {
            if (input.Any(row => row.Length != input[0].Length))
            {
                throw new ArgumentException("\nYour grid should have the same width for all rows. Please enter a new input.");
            }
        }

        private static void CheckOnlyPeriodsAndXCharactersAreUsed(List<string> input)
        {
            if (input.Any(row => row.Any(character => char.ToLower(character) != 'x' && character != '.')))
            {
                throw new ArgumentException("\nYou can only use x and . characters in your input. Please enter a new input.");
            }        
        }
    }
}