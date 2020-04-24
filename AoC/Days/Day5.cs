using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Serilog;

namespace AoC.Day5
{
    internal class Day5 : DayBase
    {
        private const string InputFile = "AoC/input/day5.txt";
        private readonly List<int> Intcode = File.ReadAllText(InputFile)
            .Split(",")
            .Select(n => Int32.Parse(n))
            .ToList();
        internal Day5() { }
        internal override void MainA()
        {
            new Computer(Intcode)
                .AddInputs(new List<int> { 1 })
                .Run()
                .Outputs
                .ForEach(x => Console.WriteLine($"{x}"));
        }
        internal override void MainB()
        {
            new Computer(Intcode)
                .AddInputs(new List<int> { 5 })
                .Run()
                .Outputs
                .ForEach(x => Console.WriteLine($"{x}"));
        }
    }
}