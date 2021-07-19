using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.GameOfLifeLogic
{
    public class Grid
    {
        public List<List<Cell>> Cells { get; }

        public Grid(int rows, int columns, List<Point> initialLiveCells)
        {
            Cells = Enumerable.Range(0, rows)
                .Select(row => Enumerable.Range(0, columns)
                    .Select(column => initialLiveCells
                        .Contains(new Point(row, column)) ? Cell.Alive: Cell.Dead)
                    .ToList())
                .ToList();
        }

        public Grid(List<List<Cell>> cells)
        {
            Cells = cells;
        }
        public List<Cell> GetAdjacentCells(int x, int y)
            {
                var rowsToCheck = Enumerable.Range(x - 1, 3)
                    .Select(rowIndex => CalculateWrapAroundIndexForDimension(rowIndex, Cells.Count));
                var columnsToCheck = Enumerable.Range(y - 1, 3)
                    .Select(columnIndex => CalculateWrapAroundIndexForDimension(columnIndex, Cells[0].Count));
                var coordsToCheck = rowsToCheck
                    .SelectMany(line => columnsToCheck
                        .Select(column => new {Line = line, Column = column}));
                var adjacentCoords = coordsToCheck
                    .Where(coords => !(coords.Line == x && coords.Column == y));

                return
                    adjacentCoords
                        .Select(coords => Cells[coords.Line][coords.Column]).ToList();
            }

            private static int CalculateWrapAroundIndexForDimension(int i, int dimensionSize)
            {
                return (i + dimensionSize) % dimensionSize;
            }
    }
}
