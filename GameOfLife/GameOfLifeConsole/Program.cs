using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var methodOfInput = UserInterface.AskForMethodOfInput().ToUpper();
            var input = InputValidator.GetValidInput(methodOfInput);
            var grid = InputConverter.ConvertInputToGrid(input);
            var world = new World(grid);
            new Game(world).RunGenerations();
        }
    }
}