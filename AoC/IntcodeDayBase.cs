using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace AoC
{
    internal abstract class IntcodeDayBase : DayBase
    {
        protected static List<int> ParseIntcodeFile(string inputFile)
        {
            return File.ReadAllText(inputFile)
                .Split(",")
                .Select(n => Int32.Parse(n))
                .ToList();
        }
    }
}