using System;
using System.Collections.Generic;
using System.IO;
using GameOfLife;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class StringInputTests
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
            Assert.Equal(expectedResult, StringInput.GetInputFrom("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/input.txt"));
        }

        [Fact]
        public void ThrowErrorWithErrorMessageIfFileDoesNotExist()
        {
            var exception = Assert.Throws<FileNotFoundException>(() => StringInput.GetInputFrom("/Users/Leah.Filkin/input.txt"));
            Assert.Equal("That file does not exist", exception.Message);
        }

        [Fact]
        public void GetsLiveCellsFromInput()
        {
            var input = new List<string>
            {
                "...x.",
                "..x.x",
                "..xxx",
                ".xxx."
            };
            var expectedLiveCellCoords = new List<Point>
            {
                new Point(0,3),
                new Point(1,2),
                new Point(1,4),
                new Point(2,2),
                new Point(2,3),
                new Point(2,4),
                new Point(3,1),
                new Point(3,2),
                new Point(3,3)
            };

            var liveCellCoords = StringInput.GetLiveCells(input);
            
            Assert.Equal(expectedLiveCellCoords, liveCellCoords);
        }

        [Fact]
        public void ThrowErrorIfInputDoesNotConsistOfOnlyPeriodsAndXCharacters()
        {
            var input = StringInput.GetInputFrom("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/inputConsistsOfMoreThanPeriodsAndXCharacters.txt");

            Assert.Throws<ArgumentException>(() => StringInput.Validate(input));
        }

        [Fact]
        public void ThrowErrorIfInputDoesNotHaveSameDimensionsThroughoutWholeGrid()
        {
            var input = StringInput.GetInputFrom("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/inputDoesNotHaveSameDimensionsThroughout.txt");

            Assert.Throws<ArgumentException>(() => StringInput.Validate(input));
        }

        [Fact]
        public void CanConvertInputFileToGridIfValid()
        {
            var path = "/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/input.txt";
            var expectedGrid = new Grid(4, 5, new List<Point>
            {
                new Point(0, 3),
                new Point(1, 2),
                new Point(1, 4),
                new Point(2, 2),
                new Point(2, 3),
                new Point(2, 4),
                new Point(3, 1),
                new Point(3, 2),
                new Point(3, 3)
            });
            var grid = StringInput.ConvertToGrid(path);
            
            Assert.Equal(expectedGrid.Cells, grid.Cells);
        }
        
    }
}