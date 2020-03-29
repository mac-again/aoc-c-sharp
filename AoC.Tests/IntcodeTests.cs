using Xunit;
using System.Collections.Generic;

namespace AoC.Tests
{
    public class IntcodeTests
    {
        public static TheoryData<List<int>, List<int>, List<int>, List<int>> Intcodes =>
        new TheoryData<List<int>, List<int>, List<int>, List<int>>
        {
            {new List<int>{1002,4,3,4,33}, new List<int>{}, new List<int>{}, new List<int> { 1002, 4, 3, 4, 99 }},
            {new List<int>{1101,100,-1,4,0}, new List<int>{}, new List<int>{}, new List<int> { 1101, 100, -1, 4, 99 }},
        };

        [Theory]
        [MemberData(nameof(Intcodes))]
        internal void TestIntcodeMachine(
            List<int> intcode,
            List<int> input,
            List<int> output,
            List<int> expected)
        {
            Intcode.IntcodeMachine(intcode, input, output);
            Assert.Equal(intcode, expected);
        }
    }
}