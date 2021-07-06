using System.Linq;

namespace GameOfLife
{
    public class World
    {
        public Grid Grid;
        public World(Grid grid)
        {
            Grid = grid;
        }

        public void UpdateCellState(int x, int y)
        {
            var cellsToCheck = Grid.GetAdjacentCells(x, y);
            var amountOfLiveCells = cellsToCheck.Count(cell => cell == Cell.Alive);
            if (amountOfLiveCells < 2)
            {
                Grid.Cells[x][y] = Cell.Dead;
            }
        }
    }
}