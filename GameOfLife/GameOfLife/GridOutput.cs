using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GridOutput
    {
        public static string ConvertToOutput(Grid grid)
        {
            return string.Join("\n",grid.Cells.Select(
                row => string.Join("",row.Select(
                    square => square switch
                    {
                        Cell.Alive => "🟨",
                        Cell.Dead => "🟦",
                        _ => throw new ArgumentOutOfRangeException()
                    })))
            );
        }
        }
    }