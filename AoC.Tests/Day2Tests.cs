using Xunit;
using System.Collections.Generic;

namespace AoC.Tests
{
    public class Day2Tests
    {
        public static TheoryData<List<int>, List<int>> IntcodesA =>
        new TheoryData<List<int>, List<int>>
        {
            {new List<int>{1,0,0,0,99}, new List<int>{2,0,0,0,99}},
            {new List<int>{2,3,0,3,99}, new List<int>{2,3,0,6,99}},
            {new List<int>{2,4,4,5,99,0}, new List<int>{2,4,4,5,99,9801}},
            {new List<int>{1,1,1,4,99,5,6,0,99}, new List<int>{30,1,1,4,2,5,6,0,99}},
        };

        [Theory]
        [MemberData(nameof(IntcodesA))]
        internal void IntcodeMachine(List<int> input, List<int> expected)
        {
            Day2.Day2.IntcodeMachine(ref input);
            Assert.Equal(expected, input);

        }
    }
}
