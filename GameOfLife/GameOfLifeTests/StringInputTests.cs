using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class StringInputTests
    {
        [Fact]
        public void ReadInputFileIntoStrings()
        {
            var stringInput = new StringInput();
            var expectedResult = new List<string>
            {
                "...x.",
                "..x.x",
                "..xxx",
                ".xxx."
            };
            Assert.Equal(expectedResult, stringInput.TakeInput());
        }
    }
}