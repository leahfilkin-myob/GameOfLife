using System;
using System.IO;

namespace GameOfLife.GameOfLifeConsole
{
    public static class FilePathValidator
    {
        public static void CheckFileExists(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The file at {path} does not exist. Please try again.");
            } 
        }

        private static void CheckFileExtension(string path)
        {
            var indexOfExtension = path.LastIndexOf('.');
            if (indexOfExtension <= -1)
            {
                throw new ArgumentException("Please provide a path that contains a .txt file");
            }
            var extension = path.Substring(path.LastIndexOf('.'));
            if (extension != ".txt")
            {
                throw new ArgumentException("We currently only accept .txt files");
            }
        }

        public static void Validate(string path)
        {
            CheckFileExists(path);
            CheckFileExtension(path);
        }
    }
}