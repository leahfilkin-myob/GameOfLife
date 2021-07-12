namespace GameOfLife.GameOfLifeConsole
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