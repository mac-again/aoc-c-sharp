using System;
using System.IO;
using System.Linq;

using AoC;

namespace AoC.Day1
{
    internal class Day1 : DayBase
    {
        private const string InputFile = "AoC/input/day1.txt";
        internal Day1() { }
        internal override void MainA()
        {
            var massNeeded = File.ReadLines(InputFile).Select(m => (Int32.Parse(m) / 3) - 2).Sum();
            Console.WriteLine("Mass {0}", massNeeded);
        }
        internal override void MainB()
        {
            var massNeeded = File.ReadLines(InputFile)
                .Select(m => ComplexRequiredFuel(Int32.Parse(m)))
                .Sum();
            Console.WriteLine("Mass {0}", massNeeded);
        }
        internal static int BasicRequiredFuel(int mass)
        {
            var fuel = (mass / 3) - 2;
            return Math.Max(fuel, 0);
        }

        internal static int ComplexRequiredFuel(int mass)
        {
            var fuel = BasicRequiredFuel(mass);
            fuel += fuel > 0 ? ComplexRequiredFuel(fuel) : 0;
            return fuel;
        }
    }
}
