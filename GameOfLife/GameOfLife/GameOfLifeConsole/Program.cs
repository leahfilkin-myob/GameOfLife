namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = UserInterface.AskForPath();
            var grid = StringInput.ConvertToGrid(path);
            var world = new World(grid);
            new Game(world).RunGenerations();
        }
    }
}