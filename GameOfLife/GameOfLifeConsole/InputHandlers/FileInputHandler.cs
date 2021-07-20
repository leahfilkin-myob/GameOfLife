using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole.InputHandlers
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
                throw new FileNotFoundException($"\nThe file at {path} does not exist. Please try again.");
            } 
        }
        
        private static void CheckFileExtension(string path)
        {
            var file = path.Substring(path.LastIndexOf('/') + 1);
            var extensionIndex = file.LastIndexOf('.');
            if (extensionIndex <= -1)
            {
                throw new ArgumentException("\nPlease provide a path that contains a file with an extension");
            }
            var extension = file.Substring(file.LastIndexOf('.'));
            if (extension != ".txt")
            {
                throw new ArgumentException("\nWe currently only accept .txt files");
            }
        }
    }
}