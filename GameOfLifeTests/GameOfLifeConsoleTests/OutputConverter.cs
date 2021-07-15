using System.Collections.Generic;
using GameOfLife;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class StringOutputTests
    {
        [Fact]
        public void ConvertsGridToConsoleFriendlyFormat()
        {
            var grid = new Grid(3,3, new List<Point> {new Point(0,0)});
            var expectedOutput = "🟨🟦🟦\n🟦🟦🟦\n🟦🟦🟦";

            var output = StringOutput.ConvertToOutput(grid);
            
            Assert.Equal(expectedOutput, output);
        }
    }
}