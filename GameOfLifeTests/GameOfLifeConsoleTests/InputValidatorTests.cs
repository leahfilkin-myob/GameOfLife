using System;
using GameOfLife.GameOfLifeConsole;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class InputValidatorTests
    {
        [Theory]
        [InlineData("inputConsistsOfMoreThanPeriodsAndXCharacters.txt")]
        [InlineData("inputDoesNotHaveSameDimensionsThroughout.txt")]
        [InlineData("inputWithNoLiveCells.txt")]
        public void ThrowErrorIfInputIsIncorrect(string file)
        {
            var input = UserInterface.ReadInputFromFile(
                "/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLifeTests/TestInputFiles/" + file);

            Assert.Throws<ArgumentException>(() => InputValidator.Validate(input));
        }

        [Fact]
        public void ThrowErrorIfInputMethodChoiceIsNotOneOfTheInputMethodTypes()
        {
            Assert.Throws<InvalidOperationException>( () =>InputValidator.Validate("X"));
            
        }
    }
}