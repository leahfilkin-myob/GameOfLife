using System;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var methodOfInput = UserInterface.AskForMethodOfInput();
                var input = UserInterface.HandleInput(methodOfInput);
                // FilePathValidator.CheckFileExists(Environment.GetEnvironmentVariable("FilePath"));
                // File.ReadLines(Environment.GetEnvironmentVariable("FilePath")).ToList();
                var grid = StringInput.ConvertToGrid(input);
                var world = new World(grid);
                new Game(world).RunGenerations();
            }
            catch (ArgumentException a)
            {
                Console.WriteLine(a.Message);
            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
            }
        }
    }
}