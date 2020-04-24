using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Serilog;

namespace AoC.Day7
{
    internal class Day7 : IntcodeDayBase
    {
        private readonly List<int> BaseIntcode = ParseIntcodeFile("AoC/input/day7.txt");
        internal Day7() { }
        internal override void MainA()
        {
            var answer = GetPerms(Enumerable.Range(0, 5))
                .Select(phases => Enumerable.Range(0, 5)
                    .Aggregate(0, (output, num) => Amplify(phases[num], output)))
                .Max();
            Log.Information("Answer: {answer}", answer);
        }

        private static IEnumerable<List<int>> GetPerms(IEnumerable<int> input)
        {
            // Eliminate a number, work out all perms of the smaller list and
            // add the number back at the end. Input actually needs to be an
            // enumerable that is not used up I think
            return !input.Any() ? new List<List<int>> { new List<int> { } } : input
                .SelectMany(x => GetPerms(input.Where(y => y != x))
                    .Select(y => y.Append(x).ToList()));
        }

        private int Amplify(int phase, int inputNum)
        {
            return new Computer(BaseIntcode)
                .AddInputs(new List<int> { phase, inputNum })
                .Run()
                .Outputs
                .Last();
        }

        private class ThrusterChain
        {
            internal List<Computer> Thrusters = new List<Computer>();
            internal ThrusterChain(List<int> intcode, IEnumerable<int> phases)
            {
                Thrusters.AddRange(phases.Select(p => new Computer(intcode)
                    .AddInput(p)
                    .StopAtOutput()));
            }

            internal int Run(int input)
            {
                return Thrusters.Any(t => t.Finished) ? input :
                    Run(Thrusters.Aggregate(input, (output, thruster) =>
                        thruster.AddInput(output).Run().Outputs.Last()));
            }
        }

        internal override void MainB()
        {
            var answer = GetPerms(Enumerable.Range(5, 5))
                .Select(perm => new ThrusterChain(BaseIntcode, perm).Run(0))
                .Max();
            Log.Information("Answer: {answer}", answer);
        }

    }
}