using GameOfLife.GameOfLifeConsole;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = UserInterface.AskForPath();
            var world = new World(StringInput.ConvertToGrid(path));
            new Game(world).RunGenerations();
        }
    }
}