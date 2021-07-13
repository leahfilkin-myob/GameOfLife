using System.IO;

namespace GameOfLife.GameOfLifeConsole
{
    public static class FilePathValidator
    {
        public static void CheckFileExists(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The file at {path} does not exist");
            } 
        }
    }
}