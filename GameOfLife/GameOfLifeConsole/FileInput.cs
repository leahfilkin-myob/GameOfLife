using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public class FileInput : IInput
    {
        public List<string> GetInput()
        {
            var path = GetPath();
            FilePathValidator.Validate(path);
            return ReadInputFromFile(path);
        }
        
        private static string GetPath()
        {
            Console.WriteLine("Please enter the path where you've kept your starting field:");
            return Console.ReadLine();
        }

        private static List<string> ReadInputFromFile(string path)
        {
            return File.ReadLines(path).ToList();
        }

    }
}