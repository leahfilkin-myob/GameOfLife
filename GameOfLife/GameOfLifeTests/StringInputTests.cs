using System;
using System.Collections.Generic;
using System.IO;
using GameOfLife;
using GameOfLife.GameOfLifeConsole;
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
            Assert.Equal(expectedResult, stringInput.ReadInputFile("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/input.txt"));
        }

        [Fact]
        public void ThrowErrorWithErrorMessageIfFileDoesNotExist()
        {
            var stringInput = new StringInput();
            
            var exception = Assert.Throws<FileNotFoundException>(() => stringInput.ReadInputFile("/Users/Leah.Filkin/input.txt"));
            Assert.Equal("That file does not exist", exception.Message);
        }

        [Fact]
        public void GetsLiveCellsFromInput()
        {
            var stringInput = new StringInput();
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

            var liveCellCoords = stringInput.GetLiveCells(input);
            
            Assert.Equal(expectedLiveCellCoords, liveCellCoords);
        }

        [Fact]
        public void ThrowErrorIfInputDoesNotConsistOfOnlyPeriodsAndXCharacters()
        {
            var stringInput = new StringInput();

            var input = stringInput.ReadInputFile("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/inputConsistsOfMoreThanPeriodsAndXCharacters.txt");

            Assert.Throws<ArgumentException>(() => stringInput.Validate(input));
        }

        [Fact]
        public void ThrowErrorIfInputDoesNotHaveSameDimensionsThroughoutWholeGrid()
        {
            var stringInput = new StringInput();
   
            var input = stringInput.ReadInputFile("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/inputDoesNotHaveSameDimensionsThroughout.txt");

            Assert.Throws<ArgumentException>(() => stringInput.Validate(input));
        }

        [Fact]
        public void CanConvertInputToGrid()
        {
            var stringInput = new StringInput();
            var input = stringInput.ReadInputFile("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/input.txt");
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
            var grid = stringInput.ConvertToGrid(input);
            
            Assert.Equal(expectedGrid.Cells, grid.Cells);
        }
        
    }
}