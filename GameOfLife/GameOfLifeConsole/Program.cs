using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputHandler supportedInputMethod;
            while (true)
            {
                try
                {
                    var inputChoice = UserInterface.GetMethodOfInput().ToUpper();
                    var inputMethod = InputValidator.ValidateThatInputMethodChoiceIsTypedCorrectly(inputChoice);
                    supportedInputMethod = InputValidator.ValidateThatInputMethodTypeIsSupported(inputMethod);
                    break;
                }
                catch (ArgumentOutOfRangeException ie)
                {
                    Console.WriteLine(ie.Message);
                }
            }

            Grid grid;
            while (true)
            {
                try
                {
                    var input = supportedInputMethod.GetInput();
                    grid = InputValidator.ConvertInputToGrid(input);
                    break;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
            var world = new World(grid);
            new Game(world).RunGenerations();
        }
    }
}