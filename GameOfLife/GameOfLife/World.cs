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

        private int GetNumberOfAdjacentLiveCells(int x, int y)
        {
            var cellsToCheck = Grid.GetAdjacentCells(x, y);
            return cellsToCheck.Count(cell => cell == Cell.Alive);
        }

        private bool CellShouldDie(int x, int y)
        {
            return GetNumberOfAdjacentLiveCells(x, y) < 2 || GetNumberOfAdjacentLiveCells(x, y) > 3;
        }

        public void UpdateCell(int x, int y)
        {
            if (CellShouldDie(x, y))
            {
                Grid.Cells[x][y] = Cell.Dead;
            }
            if (CellShouldComeAlive(x, y))
            {
                Grid.Cells[x][y] = Cell.Alive;
            }
        }

        private bool CellShouldComeAlive(int x, int y)
        {
            return GetNumberOfAdjacentLiveCells(x, y) == 3;
        }
    }
}