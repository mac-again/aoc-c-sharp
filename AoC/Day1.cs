using System;
using System.IO;
using System.Linq;

namespace AoC.Day1
{
    internal class Day1
    {
        internal Day1() { }
        internal void Main()
        {
            Main1();
            Main2();
        }
        internal void Main1()
        {
            var massNeeded = File.ReadLines("input/day1.txt").Select(m => (Int32.Parse(m) / 3) - 2).Sum();
            Console.WriteLine("Mass {0}", massNeeded);
        }
        internal void Main2()
        {
            var massNeeded = File.ReadLines("input/day1.txt")
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
