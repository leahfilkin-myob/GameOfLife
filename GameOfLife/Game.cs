using System;
using System.Threading;
using GameOfLife.GameOfLifeConsole;

namespace GameOfLife
{
    public class Game
    {
        private readonly World _world;
        
        public Game(World world)
        {
            _world = world;
        }
        
        public void RunGenerations()
        {
            const int milliseconds = 100;
            while (true)
            {
                Thread.Sleep(milliseconds);
                Console.Clear();
                Console.WriteLine(StringOutput.ConvertToOutput(_world.Grid));
                _world.RunOneGeneration();
            }
        }
    }
}