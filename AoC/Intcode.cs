using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    internal class Intcode
    {
        // Re-factor so no longer static which should allow the params bits to
        // be simplified and some replication reduced. Also, add tests for day 2
        // and 5 so you can refactor without breaking.

        internal static void IntcodeMachine(
            List<int> intcode,
            List<int> input,
            List<int> output)
        {
            var index = 0;

            // Probably only ever use with ++, ooh could this be a property so
            // it gets auto incremented when used? Can probably do the same for
            // index but implement on get and not set
            var inputIndex = 0;

            while (true)
            {
                var fullOpcode = intcode[index];
                var opcode = fullOpcode % 100;
                int[] param = new int[2];
                // The third write to parameter is never in immediate mode (at least for now)
                switch (opcode)
                {
                    // Commonise but use the operator, probs need class instance
                    case 1:
                        param[0] = intcode[index] % 1_000 - opcode == 0 ? intcode[intcode[index + 1]] : intcode[index + 1];
                        param[1] = intcode[index] % 10_000 - intcode[index] % 1_000 == 0 ? intcode[intcode[index + 2]] : intcode[index + 2];
                        intcode[intcode[index + 3]] = param[0] + param[1];
                        index += 4;
                        break;
                    case 2:
                        param[0] = intcode[index] % 1_000 - opcode == 0 ? intcode[intcode[index + 1]] : intcode[index + 1];
                        param[1] = intcode[index] % 10_000 - intcode[index] % 1_000 == 0 ? intcode[intcode[index + 2]] : intcode[index + 2];
                        intcode[intcode[index + 3]] = param[0] * param[1];
                        index += 4;
                        break;

                    case 3:
                        intcode[intcode[index + 1]] = input[inputIndex++];
                        index += 2;
                        break;
                    case 4:
                        output.Add(fullOpcode % 1000 - fullOpcode % 100 == 0 ? intcode[intcode[index + 1]] : intcode[index + 1]);
                        index += 2;
                        break;

                    // Again commonise
                    case 5:
                        param[0] = intcode[index] % 1_000 - opcode == 0 ? intcode[intcode[index + 1]] : intcode[index + 1];
                        // Might not be wise calculating param 2 if it's not
                        // needed as it might throw errors
                        param[1] = intcode[index] % 10_000 - intcode[index] % 1_000 == 0 ? intcode[intcode[index + 2]] : intcode[index + 2];
                        index = param[0] != 0 ? param[1] : index + 3;
                        break;
                    case 6:
                        param[0] = intcode[index] % 1_000 - opcode == 0 ? intcode[intcode[index + 1]] : intcode[index + 1];
                        // Might not be wise calculating param 2 if it's not
                        // needed as it might throw errors
                        param[1] = intcode[index] % 10_000 - intcode[index] % 1_000 == 0 ? intcode[intcode[index + 2]] : intcode[index + 2];
                        index = param[0] == 0 ? param[1] : index + 3;
                        break;

                    // More similar to 1 and 2 but a bit like the above
                    case 7:
                        param[0] = intcode[index] % 1_000 - opcode == 0 ? intcode[intcode[index + 1]] : intcode[index + 1];
                        param[1] = intcode[index] % 10_000 - intcode[index] % 1_000 == 0 ? intcode[intcode[index + 2]] : intcode[index + 2];
                        // Might not be wise calculating param 3 if it's not
                        // needed as it might throw errors, param 3 is always position mode
                        intcode[intcode[index + 3]] = param[0] < param[1] ? 1 : 0;
                        index += 4;
                        break;
                    case 8:
                        param[0] = intcode[index] % 1_000 - opcode == 0 ? intcode[intcode[index + 1]] : intcode[index + 1];
                        param[1] = intcode[index] % 10_000 - intcode[index] % 1_000 == 0 ? intcode[intcode[index + 2]] : intcode[index + 2];
                        // Might not be wise calculating param 3 if it's not
                        // needed as it might throw errors, param 3 is always position mode
                        intcode[intcode[index + 3]] = param[0] == param[1] ? 1 : 0;
                        index += 4;
                        break;

                    case 99:
                        // Add support for checking an ouptut called immediately before this
                        Console.WriteLine("Opcode 99 => Finished!");
                        index += 1;
                        return;
                    default:
                        Console.WriteLine("UNRECOGNISED OPCODE {0}, STOPPING", opcode);
                        return;
                }
            }
        }


    }
}