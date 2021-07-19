using System.Collections.Generic;

namespace GameOfLife.GameOfLifeConsole
{
    public interface IInputHandler
    {
        public List<string> GetInput();
    }
}