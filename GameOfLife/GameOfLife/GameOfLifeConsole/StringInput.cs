using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public class StringInput
    {

        public List<string> ReadInputFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("That file does not exist");
            }
            return File.ReadLines(path).ToList();
        }

        public List<Point> GetLiveCells(List<string> input)
        {
            var indexesAsPoints = input.SelectMany((row, i) => row
                .Select((square, j) => new Point(i, j)));
            return
                indexesAsPoints.Where(point => char.ToLower(input[point.X][point.Y]) == 'x').ToList();
        }

        public void Validate(List<string> input)
        {
            if (input.Any(row => row.Any(character => char.ToLower(character) != 'x' && character != '.')))
            {
                throw new ArgumentException("You can only use x and . characters in your input");
            }
            if (input.Any(row => row.Length != input[0].Length))
            {
                throw new ArgumentException("Your grid should have the same width for all rows");
            }
        }

        public Grid ConvertToGrid(List<string> input)
        {
            Validate(input);
            return new Grid(input.Count, input[0].Length, GetLiveCells(input));
        }
    }
}