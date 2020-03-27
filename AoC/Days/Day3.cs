using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using AoC;

namespace AoC.Day3
{
    internal class Day3 : DayBase
    {
        private const string InputFile = "AoC/input/day3.txt";
        internal Day3() { }
        internal override void MainA()
        {
            var lines = File.ReadAllLines(InputFile);
            var parsedLines = lines.Select(l => l.Split(",")
                .Select(m => (dir: m.First(), len: Int32.Parse(m.Substring(1, m.Length - 1)))))
                .ToList();

            // Only need to make one of these then compare each of the next on
            // the fly
            var points1 = MakePoints(parsedLines[0]);
            var points2 = MakePoints(parsedLines[1]);

            var mins = points1.Intersect(points2).Select(p => Math.Abs(p.x) + Math.Abs(p.y)).Min();
            Console.WriteLine(mins);
        }
        internal List<(int x, int y)> MakePoints(IEnumerable<(char dir, int len)> instructions)
        {
            var points = new List<(int x, int y)> { (x: 0, y: 0) };
            foreach (var inst in instructions)
            {
                switch (inst.dir)
                {
                    case 'U':
                        points.AddRange(
                            Enumerable
                            .Range(1, inst.len)
                            .Select(n => (points.Last().x, points.Last().y + 1)));
                        break;
                    case 'D':
                        points.AddRange(
                            Enumerable
                            .Range(1, inst.len)
                            .Select(n => (points.Last().x, points.Last().y - 1)));
                        break;
                    case 'L':
                        points.AddRange(
                            Enumerable
                            .Range(1, inst.len)
                            .Select(n => (points.Last().x - 1, points.Last().y)));
                        break;
                    case 'R':
                        points.AddRange(
                            Enumerable
                            .Range(1, inst.len)
                            .Select(n => (points.Last().x + 1, points.Last().y)));
                        break;
                    default:
                        Console.WriteLine("Invalid Instruction!");
                        return points;
                }
            }
            points.Remove((x: 0, y: 0));
            return points;
        }
        internal override void MainB()
        {
            var lines = File.ReadAllLines(InputFile);
            var parsedLines = lines.Select(l => l.Split(",")
                .Select(m => (dir: m.First(), len: Int32.Parse(m.Substring(1, m.Length - 1)))))
                .ToList();

            // Only need to make one of these then compare each of the next on
            // the fly
            var points1 = MakePoints(parsedLines[0]);
            var points2 = MakePoints(parsedLines[1]);

            var min = points1
                .Intersect(points2)
                .Select(p => points1.IndexOf(p) + points2.IndexOf(p) + 2) // 0,0 has been removed so nee to account for an extra step each
                .Min();

            Console.WriteLine(min);
        }
    }
}
