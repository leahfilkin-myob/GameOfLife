using System;
using System.IO;
using GameOfLife.GameOfLifeConsole;
using GameOfLife.GameOfLifeConsole.InputHandlers;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class FileInputHandlerTests
    {
        [Fact]
        public void ThrowErrorWithCustomErrorMessageIfFileDoesNotExist()
        {
            var path = "/../../../inputThatDoesntExist.txt";
            var exception = Assert.Throws<FileNotFoundException>(() => FileInputHandler.CheckFileExists(path));
            Assert.Equal($"\nThe file at {Path.GetFullPath(path)} does not exist. Please try again.", exception.Message);
        }

        [Fact]
        public void ThrowErrorIfFileIsNotTxt()
        {
            Assert.Throws<ArgumentException>(() => FileInputHandler.ValidateFileInPath("../../../TestInputFiles/input.json"));
        }

        [Fact]
        public void ThrowErrorIfFileHasNoExtension()
        {
            Assert.Throws<ArgumentException>(() => FileInputHandler.ValidateFileInPath("../../../TestInputFiles/inputWithNoExtension"));
        }
    }
}