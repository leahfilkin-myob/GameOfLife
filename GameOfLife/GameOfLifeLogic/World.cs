using System.Linq;

namespace GameOfLife.GameOfLifeLogic
{
    public class World
    {
        public Grid Grid { get; private set; }
        public World(Grid grid)
        {
            Grid = grid;
        }

        private int GetNumberOfAdjacentLiveCells(int x, int y)
        {
            var cellsToCheck = Grid.GetAdjacentCells(x, y);
            return cellsToCheck.Count(cell => cell == Cell.Alive);
        }
        

        private Cell GetCellsFate(int x, int y)
        {
            if (CellShouldDie(x, y))
            {
                return Cell.Dead;
            }
            if (CellShouldComeAlive(x, y))
            {
                return Cell.Alive;
            }
            return Grid.Cells[x][y];
        }
        
        private bool CellShouldDie(int x, int y)
        {
            return GetNumberOfAdjacentLiveCells(x, y) < 2 || GetNumberOfAdjacentLiveCells(x, y) > 3;
        }

        private bool CellShouldComeAlive(int x, int y)
        {
            return GetNumberOfAdjacentLiveCells(x, y) == 3;
        }

        public void RunOneGeneration()
        {
            var cellsToCheck = Grid.Cells
                .Select((row, i) => row
                    .Select((cell, j) => new {Line = i, Column = j, Cell = cell}));
            
            Grid = new Grid(
                cellsToCheck.Select(cells => cells
                .Select(cell => GetCellsFate(cell.Line, cell.Column)).ToList()).ToList());
        }
    }
}