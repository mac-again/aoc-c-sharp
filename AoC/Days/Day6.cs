using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace AoC.Day6
{
    internal class Day6 : DayBase
    {
        private const string InputFile = "AoC/input/day6.txt";
        internal Day6() { }
        internal override void MainA()
        {
            var orbits = File.ReadLines(InputFile)
                .Select(x => x.Split( /*(*/ ')'))
                .GroupBy(x => x[0], x => x[1])
                .ToDictionary(x => x.Key, x => x.ToList());

            // This currently does loads of extra work as it will add up each
            // planets total for thing it orbits recursively
            var numOrbs = orbits.Keys.Select(x => NumOrbs(x, orbits)).Sum();
            Console.WriteLine(numOrbs);
        }
        internal override void MainB()
        {

        }

        internal static int NumOrbs(string name, Dictionary<string, List<string>> orbits)
        {
            return orbits.Keys.Contains(name) ? orbits[name].Select(x => 1 + NumOrbs(x, orbits)).Sum() : 0;
        }
    }
}