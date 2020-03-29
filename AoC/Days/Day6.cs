using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace AoC.Day6
{
    internal class Day6 : DayBase
    {
        private const string InputFile = "AoC/input/day6.txt";
        private readonly Dictionary<string, List<string>> Orbits;
        internal Day6()
        {
            Orbits = File.ReadLines(InputFile)
                .Select(x => x.Split( /*(*/ ')'))
                .GroupBy(x => x[0], x => x[1])
                .ToDictionary(x => x.Key, x => x.ToList());
        }
        internal override void MainA()
        {
            // This currently does loads of extra work as it will add up each
            // planets total for thing it orbits recursively
            var numOrbs = Orbits.Keys.Select(x => NumOrbs(x, Orbits)).Sum();
            Console.WriteLine(numOrbs);

            // Second Method, Quicker but doesn't use pure function
            Total = 0;
            NumOrbs("COM", Orbits);
            Console.WriteLine(Total);

        }
        internal override void MainB()
        {
            // Build a reversed Orbits dict instead! then it's much easier
            var pathFromSan = new List<string> { };
            AddNext("SAN", pathFromSan);
            var pathFromYou = new List<string> { };
            AddNext("YOU", pathFromYou);

            var youIndex = pathFromSan.Select(x => pathFromYou.IndexOf(x)).Where(y => y != -1).Min();
            var sanIndex = pathFromSan.IndexOf(pathFromYou[youIndex]);

            // Don't step to the ends so -2
            var distance = sanIndex + youIndex - 2;
            Console.WriteLine(distance);
        }

        internal void AddNext(string name, List<string> path)
        {
            path.Add(name);
            if (name != "COM")
            {
                AddNext(Orbits.Keys.Where(x => Orbits[x].Contains(name)).Single(), path);
            }
        }

        private static int Total = 0;
        internal static int NumOrbs(string name, Dictionary<string, List<string>> orbits)
        {
            var count = orbits.Keys.Contains(name) ? orbits[name].Select(x => 1 + NumOrbs(x, orbits)).Sum() : 0;
            Total += count;
            return count;
        }
    }
}