using System;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("AoC.Tests")]
namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running");
            var day = new Day1.Day1();
            day.Main();
        }
    }
}
