using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC.Day5
{
    internal class Day5 : DayBase
    {
        private const string InputFile = "AoC/input/day5.txt";
        internal Day5() { }
        internal override void MainA()
        {
            var intcode = File.ReadAllText(InputFile)
                .Split(",")
                .Select(n => Int32.Parse(n))
                .ToList();
            var output = new List<int>();

            Intcode.IntcodeMachine(intcode, new List<int> { 1 }, output);
            Console.WriteLine(output.Find(n => n != 0));
        }
        internal override void MainB()
        {
            // TODO: Do boring setup only once rather in both cases
            var intcode = File.ReadAllText(InputFile)
                .Split(",")
                .Select(n => Int32.Parse(n))
                .ToList();
            var output = new List<int>();

            Intcode.IntcodeMachine(intcode, new List<int> { 5 }, output);
            Console.WriteLine(output.Single());
        }
    }
}