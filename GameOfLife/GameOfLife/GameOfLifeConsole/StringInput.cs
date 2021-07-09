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
                indexesAsPoints.Where(point => input[point.X][point.Y] == 'x').ToList();
        }
    }
}