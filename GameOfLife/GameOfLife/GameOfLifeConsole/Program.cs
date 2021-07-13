using System;
using System.Collections.Generic;

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
                var grid = StringInput.ConvertToGrid(input);
                var world = new World(grid);
                new Game(world).RunGenerations();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}