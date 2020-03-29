using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

using AoC.Day6;

namespace AoC.Tests
{
    public class Day6Tests
    {
        public static TheoryData<Dictionary<string, List<string>>> Orbits =>
        new TheoryData<Dictionary<string, List<string>>>
        {
            @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L"
                .Split('\n')
                .Select(x => x.Split( /*(*/ ')'))
                .GroupBy(x => x[0], x => x[1])
                .ToDictionary(x => x.Key, x => x.ToList())
        };

        [Theory]
        [MemberData(nameof(Orbits))]
        internal void TestNumOrbs(Dictionary<string, List<string>> orbits)
        {
            Assert.Equal(1, Day6.Day6.NumOrbs("K", orbits));
            Assert.Equal(4, Day6.Day6.NumOrbs("E", orbits));
            Assert.Equal(6, Day6.Day6.NumOrbs("D", orbits));
            Assert.Equal(11, Day6.Day6.NumOrbs("COM", orbits));
            Assert.Equal(42, orbits.Keys.Select(y => Day6.Day6.NumOrbs(y, orbits)).Sum());
            // var answer = orbits.Keys.
            // ToList().
            // Select(x => orbits[x].Select(y => Day6.Day6.NumOrbs(y, orbits)).Sum())
            // .Sum();

            // Assert.Equal(42, answer);
        }
    }
}
