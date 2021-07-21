using System;
using System.Collections.Generic;

namespace GameOfLife.GameOfLifeConsole.InputHandlers
{
    public interface IInputHandler
    {
        public List<string> GetInput();
        
        public static string GetMethodOfInput()
        {
            Console.Write("Please enter your method of input: enter F for file and C for console: ");
            return Console.ReadLine();
        }
    }
}