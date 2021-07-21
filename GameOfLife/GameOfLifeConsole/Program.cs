using GameOfLife.GameOfLifeLogic;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHandler = InitialStateGenerator.GenerateInputHandler();
            var grid = InitialStateGenerator.GenerateInputGrid(inputHandler);
            new Game(new World(grid)).RunGenerations();
        }
    }
}