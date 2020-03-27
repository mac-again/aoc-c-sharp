using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Day4
{
    internal class Day4 : DayBase
    {
        private const string Input = "265275-781584";
        internal Day4() { }
        internal override void MainA()
        {
            var splits = Input.Split('-').Select(s => Int32.Parse(s)).ToArray();
            var answer = Enumerable
                .Range(splits[0], splits[1] - splits[0] + 1)
                .Select(s => s.ToString())
                .Where(s => Enumerable.Range(0, 5).Where(n => s[n + 1] == s[n]).Any())
                .Where(s => Enumerable.Range(0, 5).Where(n => s[n + 1] >= s[n]).Count() == 5)
                .Count();
            Console.WriteLine(answer);
        }

        internal override void MainB()
        {
            var splits = Input.Split('-').Select(s => Int32.Parse(s)).ToArray();
            var answer = Enumerable
                .Range(splits[0], splits[1] - splits[0] + 1)
                .Select(s => s.ToString())
                .Where(s =>
                    Enumerable.Range(1, 3).Where(n => s[n + 1] == s[n] && s[n + 2] != s[n + 1] && s[n] != s[n - 1]).Any()
                    || (s[5] == s[4] && s[4] != s[3]) || (s[0] == s[1] && s[1] != s[2]))
                .Where(s => Enumerable.Range(0, 5).Where(n => s[n + 1] >= s[n]).Count() == 5)
                .Count();
            Console.WriteLine(answer);
        }
    }
}