using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC.Day7
{
    internal class Day7 : DayBase
    {
        private const string InputFile = "AoC/input/day7.txt";
        private readonly List<int> BaseIntcode;
        internal Day7()
        {
            BaseIntcode = File.ReadAllText(InputFile)
                .Split(",")
                .Select(n => Int32.Parse(n))
                .ToList();
        }
        internal override void MainA()
        {
            var answer = GetPerms(Enumerable.Range(0, 5))
                .Select(ps => Enumerable
                    .Range(0, 5)
                    .Aggregate(0, (output, num) => Amplify(ps[num], output)))
                .Max();
            Console.WriteLine(answer);
        }

        internal static IEnumerable<List<int>> GetPerms(IEnumerable<int> input)
        {
            // Eliminate a number, work out all perms of the smaller list and
            // add the number back at the end. Input actually needs to be an
            // enumerable that is not used up I think
            return !input.Any() ? new List<List<int>> { new List<int> { } } : input
                .SelectMany(x => GetPerms(input.Where(y => y != x))
                    .Select(y => y.Append(x).ToList()));
        }

        internal int Amplify(int phase, int inputNum)
        {
            var input = new List<int> { phase, inputNum };
            var intcode = new List<int>(BaseIntcode);
            var output = new List<int> { };

            Intcode.IntcodeMachine(intcode, input, output);
            return output.Single();
        }
        internal override void MainB()
        {

        }
    }
}