using System;
using System.Collections.Generic;
using System.IO;
using GameOfLife;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class InputConverterTests
    {
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

            var liveCellCoords = InputConverter.ConvertXCharactersToLiveCellPoints(input);
            
            Assert.Equal(expectedLiveCellCoords, liveCellCoords);
        }

        [Fact]
        public void CanConvertInputFileToGridIfInputIsValid()
        {
            var input = new List<string>
            {
                "...x.",
                "..x.x",
                "..xxx",
                ".xxx."
            };
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
            var grid = InputConverter.ConvertInputToGrid(input);
            
            Assert.Equal(expectedGrid.Cells, grid.Cells);
        }
        
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
            Assert.Equal(expectedResult, InputConverter.ConvertFileToInput("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLifeTests/TestInputFiles/input.txt"));
        }
        
    }
}