using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AoC.Day2
{
    class Day2 : DayBase
    {
        private const string InputFile = "AoC/input/day2.txt";

        internal Day2() { }

        internal override void MainA()
        {
            var intcode = File.ReadAllText(InputFile)
                .Split(",")
                .Select(n => Int32.Parse(n))
                .ToList();
            intcode[1] = 33;
            intcode[2] = 76;
            IntcodeMachine(ref intcode);
            Console.WriteLine(intcode[0]);

        }

        internal override void MainB()
        {
            var intcode = File.ReadAllText(InputFile)
                .Split(",")
                .Select(n => Int32.Parse(n))
                .ToList();

            var flag = false;
            foreach (var noun in Enumerable.Range(0, 100))
            {
                foreach (var verb in Enumerable.Range(0, 100))
                {
                    if (IntcodeNounVerb(intcode, noun, verb) == 19690720)
                    {
                        Console.WriteLine("{0}", 100 * noun + verb);
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    break;
                }
            }
        }

        internal static void IntcodeMachine(ref List<int> intcode)
        {
            var index = 0;

            while (true)
            {
                switch (intcode[index])
                {
                    case 1:
                        intcode[intcode[index + 3]] = intcode[intcode[index + 1]] + intcode[intcode[index + 2]];
                        index += 4;
                        break;
                    case 2:
                        intcode[intcode[index + 3]] = intcode[intcode[index + 1]] * intcode[intcode[index + 2]];
                        index += 4;
                        break;
                    case 99:
                        // Console.WriteLine("Opcode 99 => Finished!");
                        index += 1;
                        break;
                    default:
                        Console.WriteLine("UNRECOGNISED OPCODE {0}, STOPPING", intcode[index]);
                        break;
                }
            }
        }

        internal static int IntcodeNounVerb(List<int> intcode, int noun, int verb)
        {
            // Even though intcode is not passed by reference the list can be
            // modified but if it is asigned to instead then it doe not change
            // the original
            intcode = new List<int>(intcode);
            intcode[1] = noun;
            intcode[2] = verb;
            IntcodeMachine(ref intcode);
            return intcode[0];
        }
    }
}