using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLife
{
    public class StringInput
    {

        public List<string> TakeInput()
        {
            var path = "/Users/Leah.Filkin/Documents/MyProjects/GameOfLife/GameOfLife/GameOfLifeTests/TestInputFiles/input.txt";
            return File.ReadLines(path).ToList();
        }

    }
}