using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInputChoice;
            while (true)
            {
                try
                {
                    userInputChoice = UserInterface.GetMethodOfInput().ToUpper();
                    InputValidator.Validate(userInputChoice); 
                    break;
                }
                catch (InvalidOperationException ie)
                {
                    Console.WriteLine(ie.Message);
                }
            }
            var inputMethod = InputConverter.ConvertUsersInputMethodChoiceToInputMethodType(userInputChoice);

            List<string> input;
            while (true)
            {
                try
                {
                    input = UserInterface.HandleInput(inputMethod);
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
            }
            var grid = InputConverter.ConvertInputToGrid(input);
            var world = new World(grid);
            new Game(world).RunGenerations();
        }
    }
}