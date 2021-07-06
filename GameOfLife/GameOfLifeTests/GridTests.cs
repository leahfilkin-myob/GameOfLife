using System;
using System.Collections.Generic;
using System.Drawing;
using GameOfLife;
using Xunit;
using Point = GameOfLife.Point;

namespace GameOfLifeTests
{
    public class GridTests
    {
        [Fact]
        public void IsSameDimensionsAsInputsGivenToIt()
        {
            var grid = new Grid(10,20, new List<Point> {new Point(0,0)});
            
            Assert.Equal(10, grid.Cells.Count);
            Assert.Equal(20, grid.Cells[0].Count);
        }

        [Fact]
        public void CellCoordinatesGivenForInitialStateAreLive()
        {
            var grid = new Grid(10,20, new List<Point> {new Point(0,0)});
            
            Assert.Equal(Cell.Alive, grid.Cells[0][0]);
        }

        [Fact]
        public void CellsNotGivenForInitialStateAreDead()
        {
            var grid = new Grid(10,20, new List<Point> {new Point(0,0)});
            
            Assert.Equal(Cell.Dead, grid.Cells[0][1]);
        }
    }
}