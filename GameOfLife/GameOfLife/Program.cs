using System;
using System.Collections.Generic;
using GameOfLife.GameOfLifeConsole;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringInput = new StringInput();
            var path = UserInterface.AskForPath();
            var grid = stringInput.ConvertToGrid(path);
            var world = new World(grid);
            var game = new Game(world);
            game.RunGenerations();

        }
    }
}