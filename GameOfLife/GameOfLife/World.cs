using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic.FileIO;

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

        public Cell GetCellsFate(int x, int y)
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

        private bool CellShouldComeAlive(int x, int y)
        {
            return GetNumberOfAdjacentLiveCells(x, y) == 3;
        }

        public void RunOneGeneration()
        {
            var resultOfRun = new List<List<Cell>>();
            for (var i = 0; i < Grid.Cells.Count; i++)
            {
                resultOfRun.Add(new List<Cell>());
                for (var j = 0; j < Grid.Cells[0].Count; j++)
                {
                    resultOfRun[i].Add(GetCellsFate(i,j));
                }
            }
            Grid.Cells = resultOfRun;
        }
    }
}