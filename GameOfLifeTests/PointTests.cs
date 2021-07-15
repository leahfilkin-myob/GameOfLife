using System;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class PointTests
    {
        [Theory]
        [InlineData(-1, 1)]
        [InlineData(5, -10)]
        public void ThrowsErrorIfPointIsNegative(int x, int y)
        {
            Assert.Throws<ArgumentException>(() => new Point(x, y));
        }
        
    }
}