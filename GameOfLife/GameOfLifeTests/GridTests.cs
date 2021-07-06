using System;
using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GridTests
    {
        [Fact]
        public void IsSameDimensionsAsInputsGivenToIt()
        {
            var grid = new Grid(10,20);
            Assert.Equal(10, grid.Cells.Count);
            Assert.Equal(20, grid.Cells[0].Count);
        }
    }
}