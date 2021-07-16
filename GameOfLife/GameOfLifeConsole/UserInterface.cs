using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public static class UserInterface
    {
        private static List<string> GetConsoleInput()
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

        private static string GetPath()
        {
            Console.WriteLine("Please enter the path where you've kept your starting field:");
            return Console.ReadLine();
        }

        public static string GetMethodOfInput()
        {
            Console.Write("Please enter your method of input: enter F for file and C for console: ");
            return Console.ReadLine();
        }

        public static List<string> ReadInputFromFile(string path)
        {
            return File.ReadLines(path).ToList();
        }
        
        public static List<string> HandleInput(Method method)
        {
            return method switch
            {
                Method.Console => GetConsoleInput(),
                Method.File => GetFileInput(),
            };
        }

        private static List<string> GetFileInput()
        {
            var path = GetPath();
            FilePathValidator.Validate(path);
            return ReadInputFromFile(path);
        }
    }
}