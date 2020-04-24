using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace AoC
{
    internal class Computer
    {
        private enum Opcode
        {
            ADD = 1,
            MULTIPLY = 2,
            READ_INPUT = 3,
            WRITE_OUPUT = 4,
            JUMP_TRUE = 5,
            JUMP_FALSE = 6,
            LESS_THAN = 7,
            EQUAL = 8,
            STOP = 99
        }
        private enum ParamMode
        {
            POSITION = 0,
            IMMEDIATE = 1
        }
        public List<int> Intcode;
        private int InstPointer = 0;
        private List<int> Inputs = new List<int>();
        private int InputsPointer = 0;
        private List<int> _Outputs = new List<int>();
        internal List<int> Outputs { get { return _Outputs; } }
        private int OutputsPointer = -1;
        private bool _StopAtOutput = false;
        private bool _Finished = false;
        internal bool Finished { get { return _Finished; } }
        internal Computer(List<int> intcode)
        {
            // Does this copy or alter the original? It must copy if it's private?
            // Nope need to copy manually, weired that you can change private variable like this
            Intcode = new List<int>(intcode);
        }

        internal Computer Run()
        {
            while (true)
            {
                var fullOpcode = Intcode[InstPointer];
                var opcode = (Opcode)(fullOpcode % 100);

                switch (opcode)
                {
                    case Opcode.ADD:
                        {
                            var paramIndexexs = GetParamIndexes(fullOpcode, 3);
                            Intcode[paramIndexexs[2]] = Intcode[paramIndexexs[1]] + Intcode[paramIndexexs[0]];
                            InstPointer += 4;
                            break;
                        }
                    case Opcode.MULTIPLY:
                        {
                            var paramIndexexs = GetParamIndexes(fullOpcode, 3);
                            Intcode[paramIndexexs[2]] = Intcode[paramIndexexs[1]] * Intcode[paramIndexexs[0]];
                            InstPointer += 4;
                            break;
                        }
                    case Opcode.READ_INPUT:
                        {
                            Intcode[GetParamIndexes(fullOpcode, 1).Single()] = Inputs[InputsPointer++];
                            InstPointer += 2;
                            break;
                        }
                    case Opcode.WRITE_OUPUT:
                        {
                            Outputs.Add(Intcode[GetParamIndexes(fullOpcode, 1).Single()]);
                            OutputsPointer++;
                            InstPointer += 2;
                            if (_StopAtOutput) { return this; }
                            break;
                        }
                    case Opcode.JUMP_TRUE:
                        {
                            var paramIndexes = GetParamIndexes(fullOpcode, 2);
                            InstPointer = Intcode[paramIndexes[0]] != 0 ? Intcode[paramIndexes[1]] : InstPointer + 3;
                            break;
                        }
                    case Opcode.JUMP_FALSE:
                        {
                            var paramIndexes = GetParamIndexes(fullOpcode, 2);
                            InstPointer = Intcode[paramIndexes[0]] == 0 ? Intcode[paramIndexes[1]] : InstPointer + 3;
                            break;
                        }
                    case Opcode.LESS_THAN:
                        {
                            var paramIndexes = GetParamIndexes(fullOpcode, 3);
                            Intcode[paramIndexes[2]] = Intcode[paramIndexes[0]] < Intcode[paramIndexes[1]] ? 1 : 0;
                            InstPointer += 4;
                            break;
                        }
                    case Opcode.EQUAL:
                        {
                            var paramIndexes = GetParamIndexes(fullOpcode, 3);
                            Intcode[paramIndexes[2]] = Intcode[paramIndexes[0]] == Intcode[paramIndexes[1]] ? 1 : 0;
                            InstPointer += 4;
                            break;
                        }
                    case Opcode.STOP:
                        {
                            Log.Debug("Opcode 99 => Finished");
                            _Finished = true;
                            InstPointer++;
                            return this;
                        }
                    default:
                        throw new Exception($"UNRECOGNISED OPCODE {opcode}, STOPPING");
                }
            }
        }

        internal Computer AddInputs(IEnumerable<int> inputs) { Inputs.AddRange(inputs); return this; }
        internal Computer AddInput(int input) { Inputs.Add(input); return this; }
        internal Computer StopAtOutput() { _StopAtOutput = true; return this; }
        private List<int> GetParamIndexes(int opcode, int numParams)
        {
            return Enumerable.Range(1, numParams)
                .Select(x =>
                {
                    // Messy! you can do better!
                    var paramMode = (ParamMode)
                        ((opcode % Math.Pow(10, x + 2) - opcode % Math.Pow(10, x + 1)) / Math.Pow(10, x + 1));
                    switch (paramMode)
                    {
                        case ParamMode.POSITION:
                            return Intcode[InstPointer + x];
                        case ParamMode.IMMEDIATE:
                            return InstPointer + x;
                        default:
                            throw new Exception($"Invalid ParamMode: {paramMode}");
                    }
                })
                .ToList();
        }
        // private void Combine(Func<int, int, int> f, int x, int y)
        // {
        //     f(x, y);
        // }
    }
}