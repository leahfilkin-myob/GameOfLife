using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

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
            int milliseconds = 500;
            Thread.Sleep(milliseconds);
            while (true)
            {
                _world.RunOneGeneration();
                Console.WriteLine(1);
            }
        }
    }
}