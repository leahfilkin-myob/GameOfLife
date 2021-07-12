using System;

namespace GameOfLife.GameOfLifeConsole
{
    public static class UserInterface
    {
        public static string AskForPath()
        {
            Console.WriteLine("Please enter the path where you've kept your starting field:");
            return Console.ReadLine();
        }
        
    }
}