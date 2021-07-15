using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public static class UserInterface
    {
        public static List<string> GetConsoleInput()
        {
            Console.WriteLine("Please enter your grid. Enter F on a new line to finish:");
            string line;
            var input = new List<string>();
            while ((line = Console.ReadLine()) != null && line != "" && line.ToUpper() != "F") 
            {
                input.Add(line);
            }
            return input;
        }

        public static string GetValidPath()
        {
            Console.WriteLine("Please enter the path where you've kept your starting field:");
            return Console.ReadLine();
        }

        public static string AskForMethodOfInput()
        {
            Console.Write("Please enter your method of input: enter F for file and C for console: ");
            return Console.ReadLine();
        }
        
        public static List<string> HandleInput(string methodOfInput)
        {
            switch (methodOfInput.ToUpper())
            {
                case "C":
                    return GetConsoleInput();
                case "F":
                {
                    var path = GetValidPath();
                    return InputConverter.ConvertFileToInput(path);
                }
            }
            throw new InvalidOperationException("You can only enter F for file or C for console for your method of input");
        }
    }
}