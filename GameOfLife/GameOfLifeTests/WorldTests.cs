using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldTests
    {
        [Fact]
        public void TurnsLiveCellToDeadIfNoLiveNeighbours()
        {
            var world = new World(
                new Grid(10, 10, new List<Point>
                {
                    new Point(5, 5),
                }));
            
            world.UpdateCellState(5,5);

            Assert.Equal(Cell.Dead, world.Grid.Cells[5][5]);
        }

        [Fact]
        public void TurnsLiveCellToDeadIfOneLiveNeighbour()
        {
            var world = new World(
                new Grid(10, 10, new List<Point>
                {
                    new Point(5, 5),
                    new Point(5, 6),
                }));
            
            world.UpdateCellState(5,5);
            
            Assert.Equal(Cell.Dead, world.Grid.Cells[5][5]);
        }
    }
}