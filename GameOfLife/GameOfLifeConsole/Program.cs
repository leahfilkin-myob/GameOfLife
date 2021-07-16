using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var userMethodOfInput = UserInterface.GetMethodOfInput().ToUpper();
            List<string> input;
            while (true)
            {
                try
                {
                    var methodOfInput = InputConverter.ConvertUsersInputMethodChoiceToMethodType(userMethodOfInput); //write a test for this
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
                    userMethodOfInput = UserInterface.GetMethodOfInput().ToUpper();
                }
            }
            var grid = InputConverter.ConvertInputToGrid(input);
            var world = new World(grid);
            new Game(world).RunGenerations();
        }
    }
}