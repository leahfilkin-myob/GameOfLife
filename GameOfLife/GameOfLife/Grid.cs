using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid
    {
        public List<List<Cell>> Cells { get; set; }

        public Grid(int rows, int columns)
        {
            Cells = new List<List<Cell>>();
            for (var row = 0; row < rows; row++)
            {
                Cells.Add(new List<Cell>());
                for (var column = 0; column < columns; column++)
                {
                    Cells[row].Add(new Cell());
                }
            }
        }
    }
}