using System.Linq;
using GameOfLife.GameOfLifeLogic;

namespace GameOfLife.GameOfLifeConsole
{
    public static class Output
    {
        public static string ConvertToOutput(Grid grid)
        {
            return string.Join("\n",grid.Cells.Select(
                row => string.Join("",row.Select(
                    square => square is Cell.Alive ? "🟨" : "🟦" ))));
        }
        }
    }