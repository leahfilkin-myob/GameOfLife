using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public static class InputConverter
    {

        public static List<Point> ConvertXCharactersToLiveCellPoints(List<string> input)
        {
            var indexesAsPoints = input.SelectMany((row, i) => row
                .Select((square, j) => new Point(i, j)));
            return
                indexesAsPoints.Where(point => char.ToLower(input[point.X][point.Y]) == 'x').ToList();
        }

        public static Grid ConvertInputToGrid(List<string> input)
        {
            return new Grid(input.Count, input[0].Length, ConvertXCharactersToLiveCellPoints(input));
        }

        public static Method ConvertUsersInputMethodChoiceToMethodType(string userMethodOfInput)
        {
            return userMethodOfInput switch
            {
                "C" => Method.Console,
                "F" => Method.File,
                _ => throw new InvalidOperationException("You can only enter F for file or C for console for your method of input")           
            };
        }
    }
}