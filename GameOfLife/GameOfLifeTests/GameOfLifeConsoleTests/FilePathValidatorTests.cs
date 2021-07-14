using System;
using System.IO;
using GameOfLife.GameOfLifeConsole;
using Xunit;
using System.IO;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class FilePathValidatorTests
    {
        [Fact]
        public void ThrowErrorWithCustomErrorMessageIfFileDoesNotExist()
        {
            var exception = Assert.Throws<FileNotFoundException>(() => FilePathValidator.CheckFileExists("/Users/Leah.Filkin/input.txt"));
            Assert.Equal($"The file at /Users/Leah.Filkin/input.txt does not exist", exception.Message);
        }

        [Fact]
        public void ThrowErrorIfFileIsNotTxt()
        {
            Assert.Throws<ArgumentException>(() => FilePathValidator.CheckFileExtension("/input.json"));
        }
    }
}