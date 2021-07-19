using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public static class UserInterface
    {
        public static string GetMethodOfInput()
        {
            Console.Write("Please enter your method of input: enter F for file and C for console: ");
            return Console.ReadLine();
        }

        public static List<string> HandleInput(InputMethod inputMethod)
        {
            return inputMethod switch
            {
                InputMethod.Console => new ConsoleInput().GetInput(),
                InputMethod.File => new FileInput().GetInput()
            };
        }
    }
}