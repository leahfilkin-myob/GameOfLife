using System.Collections.Generic;
using System.IO;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class UserInterfaceTests
    {
        [Fact]
        public void ReadInputFileIntoStrings()
        {
            var expectedResult = new List<string>
            {
                "...x.",
                "..x.x",
                "..xxx",
                ".xxx."
            };
            Assert.Equal(expectedResult, UserInterface.GetFileInput("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLifeTests/TestInputFiles/input.txt"));
        }
    }
}