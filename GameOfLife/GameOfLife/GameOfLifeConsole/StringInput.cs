using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public static class StringInput
    {

        public static List<Point> GetLiveCells(List<string> input)
        {
            var indexesAsPoints = input.SelectMany((row, i) => row
                .Select((square, j) => new Point(i, j)));
            return
                indexesAsPoints.Where(point => char.ToLower(input[point.X][point.Y]) == 'x').ToList();
        }
        
        public static Grid ConvertToGrid(List<string> input)
        {
            
            InputValidator.Validate(input);
            return new Grid(input.Count, input[0].Length, GetLiveCells(input));
        }
    }
}