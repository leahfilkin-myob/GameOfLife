using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife.GameOfLifeConsole
{
    public class StringInput
    {

        public List<string> ReadInputFile(string path)
        {
            return File.ReadLines(path).ToList();
        }
        
        

    }
}