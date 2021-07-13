using System;
using GameOfLife;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData("inputConsistsOfMoreThanPeriodsAndXCharacters.txt")]
        [InlineData("inputDoesNotHaveSameDimensionsThroughout.txt")]
        [InlineData("inputWithNoLiveCells.txt")]
        public void ThrowErrorIfInputIsIncorrect(string file)
        {
            var input = UserInterface.GetInputFrom(
                "/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/" + file);

            Assert.Throws<ArgumentException>(() => InputValidator.Validate(input));
        }
    }
}