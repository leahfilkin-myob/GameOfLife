using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public class FileInputHandler : IInputHandler
    {
        public List<string> GetInput()
        {
            var path = UserInterface.GetPath();
            ValidateFileInPath(path);
            return ReadInputFromFile(path);
        }

        private static List<string> ReadInputFromFile(string path)
        {
            return File.ReadLines(path).ToList();
        }
        
        
        public static void ValidateFileInPath(string path)
        {
            CheckFileExists(path);
            CheckFileExtension(path);
        }
        
        public static void CheckFileExists(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The file at {path} does not exist. Please try again.");
            } 
        }
        
        private static void CheckFileExtension(string path)
        {
            var indexOfExtension = path.Substring(path.LastIndexOf('/')).LastIndexOf('.');
            if (indexOfExtension <= -1)
            {
                throw new ArgumentException("Please provide a path that contains a file with an extension");
            }
            var extension = path.Substring(indexOfExtension);
            if (extension != ".txt")
            {
                throw new ArgumentException("We currently only accept .txt files");
            }
        }
    }
}