using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public static class StringOutput
    {
        public static string ConvertToOutput(Grid grid)
        {
            return string.Join("\n",grid.Cells.Select(
                row => string.Join("",row.Select(
                    square => square is Cell.Alive ? "🟨" : "🟦" ))));
        }
        }
    }