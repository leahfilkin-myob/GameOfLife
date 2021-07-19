using System;
using System.Collections.Generic;
using System.IO;
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

        public static Grid ConvertInputToGrid(List<string> input)
        {
            Validate(input);
            return new Grid(input.Count, input[0].Length, ConvertXCharactersToLiveCellPoints(input));
        }

        public static InputMethod ValidateThatInputMethodChoiceIsTypedCorrectly(string userMethodOfInput)
        {
            return userMethodOfInput switch
            {
                "C" => InputMethod.Console,
                "F" => InputMethod.File,
                _ => throw new ArgumentOutOfRangeException(nameof(userMethodOfInput), "You have incorrectly typed one of the input options.")
            };
        }

        public static IInputHandler ValidateThatInputMethodTypeIsSupported(InputMethod inputMethod)
        {
            return inputMethod switch
            {
                InputMethod.Console => new ConsoleInputHandler(),
                InputMethod.File => new FileInputHandler(),
                _ => throw new ArgumentOutOfRangeException(nameof(inputMethod), "You have selected an input type that's not supported.")
            };
        }

        public static void Validate(List<string> input)
        {
            CheckOnlyPeriodsAndXCharactersAreUsed(input);
            CheckAllRowsHaveSameAmountOfColumns(input);
            CheckAtLeastOneLiveCellExists(input);
        }

        private static void CheckAtLeastOneLiveCellExists(List<string> input)
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