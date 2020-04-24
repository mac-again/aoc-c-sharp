using System.Security.Cryptography;
using System;
using System.Runtime.CompilerServices;
using System.Linq;
using Serilog;
using CommandLine;

[assembly: InternalsVisibleTo("AoC.Tests")]
namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            new Parser(config => { config.HelpWriter = Console.Out; })
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(config => App(config));
        }

        static void App(CommandLineOptions config)
        {
            SetupLogging(config.DebugLogs);

            var day = config.Day;

            Log.Information("Day: {day}", day);

            if (day == 0) { Scratch(); }

            IDay dayClass = null;
            switch (day)
            {
                case 1:
                    dayClass = new Day1.Day1();
                    break;
                case 2:
                    dayClass = new Day2.Day2();
                    break;
                case 3:
                    dayClass = new Day3.Day3();
                    break;
                case 4:
                    dayClass = new Day4.Day4();
                    break;
                case 5:
                    dayClass = new Day5.Day5();
                    break;
                case 6:
                    dayClass = new Day6.Day6();
                    break;
                case 7:
                    dayClass = new Day7.Day7();
                    break;
                default:
                    return;
            }

            dayClass.Main();

        }

        static void SetupLogging(bool debug)
        {
            var configuration = new LoggerConfiguration();

            if (debug) { configuration.MinimumLevel.Debug(); }

            Log.Logger = configuration
                .WriteTo
                .Console()
                .CreateLogger();
        }

        static void Scratch()
        {

        }
    }
}
