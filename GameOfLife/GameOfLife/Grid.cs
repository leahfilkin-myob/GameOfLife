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
    }
}