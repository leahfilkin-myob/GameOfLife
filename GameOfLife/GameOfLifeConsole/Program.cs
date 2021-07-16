using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var methodOfInput = UserInterface.AskForMethodOfInput().ToUpper();
            List<string> input;
            while (true)
            {
                try
                {
                    input = UserInterface.HandleInput(methodOfInput);
                    InputValidator.Validate(input);
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
                catch (InvalidOperationException ie)
                {
                    Console.WriteLine(ie.Message);
                    methodOfInput = UserInterface.AskForMethodOfInput().ToUpper();
                }
            }
            var grid = InputConverter.ConvertInputToGrid(input);
            var world = new World(grid);
            new Game(world).RunGenerations();
        }
    }
}