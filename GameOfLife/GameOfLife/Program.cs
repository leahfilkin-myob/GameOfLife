using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new World(
                new Grid(10, 10, new List<Point>
                {
                    new Point(5,4),
                    new Point(5,6),
                    new Point(6,5)
                }));
            var game = new Game(world);
            game.RunGenerations();
        }
    }
}