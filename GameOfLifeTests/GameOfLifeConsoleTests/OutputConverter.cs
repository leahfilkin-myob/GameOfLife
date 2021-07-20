using System.Collections.Generic;
using GameOfLife;
using GameOfLife.GameOfLifeConsole;
using GameOfLife.GameOfLifeLogic;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class OutputConverterTests
    {
        [Fact]
        public void ConvertsGridToConsoleFriendlyFormat()
        {
            var grid = new Grid(3,3, new List<Point> {new Point(0,0)});
            var expectedOutput = "🟨🟦🟦\n🟦🟦🟦\n🟦🟦🟦";

            var output = Output.ConvertToOutput(grid);
            
            Assert.Equal(expectedOutput, output);
        }
    }
}