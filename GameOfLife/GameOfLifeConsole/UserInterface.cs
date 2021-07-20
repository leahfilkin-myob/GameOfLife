using System;

namespace GameOfLife.GameOfLifeConsole
{
    public static class UserInterface
    {
        public static string GetMethodOfInput()
        {
            Console.Write("Please enter your method of input: enter F for file and C for console: ");
            return Console.ReadLine();
        }
    }
}