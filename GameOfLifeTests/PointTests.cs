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

        [Fact]
        public void EquatesTwoDifferentInstancesOfPointIfPointsHaveSameCoords()
        {
            var firstPoint = new Point(1, 1);
            var secondPoint = new Point(1, 1);

            Assert.Equal(firstPoint, secondPoint);
        }

        [Fact]
        public void CanGenerateHashCalculationForAPoint()
        {
            var point = new Point(5, 5);
            
            Assert.Equal(17, point.GetHashCode());
        }
        
    }
}