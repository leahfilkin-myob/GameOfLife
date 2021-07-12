using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        public List<List<Cell>> Cells { get; set; }

        public Grid(int rows, int columns, List<Point> initialLiveCells)
        {
            Cells = new List<List<Cell>>();

            for (var row = 0; row < rows; row++)
            {
                Cells.Add(new List<Cell>());
                for (var column = 0; column < columns; column++)
                {
                    Cells[row].Add(Cell.Dead);
                }
            }
            foreach (var liveCell in initialLiveCells)
            {
                Cells[liveCell.X][liveCell.Y] = Cell.Alive;
            }
        }
        
            public List<Cell> GetAdjacentCells(int x, int y)
            {
                var rowsToCheck = Enumerable.Range(x - 1, 3)
                    .Select(GetWrapAroundIndexForRow);
                var columnsToCheck = Enumerable.Range(y - 1, 3)
                    .Select(GetWrapAroundIndexForColumn);
                var coordsToCheck = rowsToCheck
                    .SelectMany(line => columnsToCheck
                        .Select(column => new {Line = line, Column = column}));
                var adjacentCoords = coordsToCheck
                    .Where(coords => !(coords.Line == x && coords.Column == y));

                return
                    adjacentCoords
                        .Select(coords => Cells[coords.Line][coords.Column]).ToList();
            }

            private int GetWrapAroundIndexForRow(int i)
            {
                return (i + Cells.Count) % Cells.Count;
            }
            
            private int GetWrapAroundIndexForColumn(int i)
            {
                return (i + Cells[0].Count) % Cells[0].Count;
            }
            
            public override bool Equals(object o)
            {
                if (o == null || GetType() != o.GetType())
                {
                    return false;
                }

                return o is Grid otherGrid && Cells == otherGrid.Cells;
            }

            public override int GetHashCode()
            {
                return (Cells != null ? Cells.GetHashCode() : 0);
            }
    }
    }
