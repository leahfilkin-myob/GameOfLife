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

        public bool CellShouldDie(int x, int y)
        {
            var cellsToCheck = Grid.GetAdjacentCells(x, y);
            var amountOfLiveCells = cellsToCheck.Count(cell => cell == Cell.Alive);
            return amountOfLiveCells < 2 || amountOfLiveCells > 3;
        }

        public void UpdateCell(int x, int y)
        {
            if (CellShouldDie(x, y))
            {
                Grid.Cells[x][y] = Cell.Dead;
            }
        }
        
    }
}