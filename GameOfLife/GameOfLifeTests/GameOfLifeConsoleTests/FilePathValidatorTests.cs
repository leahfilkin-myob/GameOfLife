using System.IO;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class FilePathValidatorTests
    {
        [Fact]
        public void ThrowErrorWithErrorMessageIfFileDoesNotExist()
        {
            var exception = Assert.Throws<FileNotFoundException>(() => FilePathValidator.CheckFileExists("/Users/Leah.Filkin/input.txt"));
            Assert.Equal($"The file at /Users/Leah.Filkin/input.txt does not exist", exception.Message);
        }
    }
}