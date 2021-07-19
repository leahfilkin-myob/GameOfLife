using System;
using System.IO;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class FileInputHandlerTests
    {
        [Fact]
        public void ThrowErrorWithCustomErrorMessageIfFileDoesNotExist()
        {
            var exception = Assert.Throws<FileNotFoundException>(() => FileInputHandler.CheckFileExists("/Users/Leah.Filkin/input.txt"));
            Assert.Equal($"The file at /Users/Leah.Filkin/input.txt does not exist. Please try again.", exception.Message);
        }

        [Fact]
        public void ThrowErrorIfFileIsNotTxt()
        {
            Assert.Throws<ArgumentException>(() => FileInputHandler.ValidateFileInPath("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLifeTests/TestInputFiles/input.json"));
        }

        [Fact]
        public void ThrowErrorIfFileHasNoExtension()
        {
            Assert.Throws<ArgumentException>(() => FileInputHandler.ValidateFileInPath("/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLifeTests/TestInputFiles/inputWithNoExtension"));
        }
    }
}