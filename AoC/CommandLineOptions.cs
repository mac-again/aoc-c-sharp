using CommandLine;

namespace AoC
{
    internal class CommandLineOptions
    {
        public CommandLineOptions(
            int day,
            bool debugLogs
        )
        {
            Day = day;
            DebugLogs = debugLogs;
        }

        [Option("day", Required = true, HelpText = "Print debug logs")]
        public int Day { get; }

        [Option("debugLogs", Default = false, HelpText = "Print debug logs")]
        public bool DebugLogs { get; }
    }
}