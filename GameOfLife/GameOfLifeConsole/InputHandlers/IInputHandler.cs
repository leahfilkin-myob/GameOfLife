using System.Collections.Generic;

namespace GameOfLife.GameOfLifeConsole.InputHandlers
{
    public interface IInputHandler
    {
        public List<string> GetInput();
    }
}