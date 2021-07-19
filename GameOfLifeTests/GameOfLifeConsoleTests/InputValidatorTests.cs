using System;
using System.Collections.Generic;
using GameOfLife;
using GameOfLife.GameOfLifeConsole;
using GameOfLife.GameOfLifeConsole.InputHandlers;
using GameOfLife.GameOfLifeLogic;
using Xunit;

namespace GameOfLifeTests.GameOfLifeConsoleTests
{
    public class InputValidatorTests
    {
        [Theory]
        [MemberData(nameof(IncorrectInput))]
        public void ThrowErrorIfInputIsIncorrect(IncorrectInputData incorrectInputData)
        {

            Assert.Throws<ArgumentException>(() => InputValidator.Validate(incorrectInputData.Input));
        }

        [Fact]
        public void ThrowErrorIfInputMethodChoiceIsNotOneOfTheInputMethodTypes()
        {
            Assert.Throws<ArgumentOutOfRangeException>( () => InputValidator.ValidateThatInputMethodChoiceIsTypedCorrectly("X"));
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
            var expectedGrid = new Grid(4,5,new List<Point>
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
            });

            var actualGrid = InputValidator.ConvertInputToGrid(input);
            
            Assert.Equal(expectedGrid.Cells, actualGrid.Cells);
        }
        
        [Theory]
        [InlineData("C", InputMethod.Console)]
        [InlineData("F", InputMethod.File)]
        public static void ConvertsUsersInputMethodChoiceToInputMethodType(string inputString, InputMethod convertedMethod)
        {
            var convertedInputMethod = InputValidator.ValidateThatInputMethodChoiceIsTypedCorrectly(inputString);
            
            Assert.Equal(convertedMethod, convertedInputMethod);
        }

        [Theory]
        [InlineData(InputMethod.Console, typeof(ConsoleInputHandler))]
        [InlineData(InputMethod.File, typeof(FileInputHandler))]
        public static void ConvertsInputMethodTypeToInstanceOfInputHandler(InputMethod inputMethod, object inputHandlerType)
        {
            var inputHandler = InputValidator.ValidateThatInputMethodTypeIsSupported(inputMethod);
            Assert.Equal(inputHandlerType, inputHandler.GetType());
        }

        public class IncorrectInputData
        {
            public List<string> Input;
        }

        public static IEnumerable<object[]> IncorrectInput =>
            new TheoryData<IncorrectInputData>
            {
                new IncorrectInputData
                {
                    Input = new List<string>
                    {
                        "...x.",
                        "..x.x",
                        ".Axx",
                        ".xxx."
                    }
                },
                new IncorrectInputData
                {
                    Input = new List<string>
                    {
                        "...x.",
                        "..x.x",
                        "..xxx",
                        ".xxx.."
                    }
                },
                new IncorrectInputData
                {
                    Input = new List<string>
                    {
                        "......",
                        "......",
                        "......",
                        "......",
                        "......",
                        "......"
                    }
                }
            };
    }
}