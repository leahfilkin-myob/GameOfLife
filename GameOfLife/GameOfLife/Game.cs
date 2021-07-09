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
            int milliseconds = 1000;
            while (true)
            {
                Thread.Sleep(milliseconds);
                Console.Clear();
                Console.WriteLine(GridOutput.ConvertToOutput(_world.Grid));
                _world.RunOneGeneration();
            }
        }
    }
}