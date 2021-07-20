using System;
using System.Collections.Generic;

namespace GameOfLife.GameOfLifeConsole.InputHandlers
{
    public class ConsoleInputHandler : IInputHandler
    {
        public List<string> GetInput()
        {
            Console.WriteLine("Please enter your grid, using the 'x' character for live cells, and the '.' character for dead cells.\nEnter D (for Done) on a new line to finish:");
            string line;
            var input = new List<string>();
            while ((line = Console.ReadLine()) != null && line != "" && line.ToUpper() != "D") 
            {
                input.Add(line);
            }
            return input;
        }
    }
}
