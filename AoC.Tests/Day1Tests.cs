using System;
using Xunit;

using AoC.Day1;

namespace AoC.Tests.Day1
{
    public class Day1Tests
    {
        public static TheoryData<int, int> TestBasicFuelData =>
        new TheoryData<int, int>
        {
            {12, 2},
            {14, 2},
            {1969, 654},
            {100756, 33583}
        };

        [Theory]
        [MemberData(nameof(TestBasicFuelData))]
        internal void TestBasicFuel(int input, int expected)
        {
            Assert.Equal(expected, AoC.Day1.Day1.BasicRequiredFuel(input));

        }

        public static TheoryData<int, int> TestComplexFuelData =>
        new TheoryData<int, int>
        {
            {14, 2},
            {1969, 966},
            {100756, 50346}
        };

        [Theory]
        [MemberData(nameof(TestComplexFuelData))]
        internal void TestComplexFuel(int input, int expected)
        {
            Assert.Equal(expected, AoC.Day1.Day1.ComplexRequiredFuel(input));

        }
    }
}
