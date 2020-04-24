using System.Reflection.Metadata.Ecma335;
using System;
using Serilog;

namespace AoC
{

    internal abstract class DayBase : IDay
    {
        // internal DayBase() { }
        public void Main()
        {
            Log.Information("Part A:");
            MainA();
            Log.Information("Part B:");
            MainB();
        }
        internal abstract void MainA();
        internal abstract void MainB();
    }
}
