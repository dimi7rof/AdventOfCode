using AdventOfCode.Samples;
using AdventOfCode.Solutions;
using Microsoft.Extensions.Primitives;

namespace AdventOfCode;

public static class Executor
{
    public static (long, long) ExecuteSolution(int year, int day, StringValues value)
    {
        var input = string.IsNullOrEmpty(value)
            ? GetSample(year, day)
            : value.FirstOrDefault()
            ?? string.Empty;

        var (partOne, partTwo) = ExecuteSolution(year, day, input);

        return (partOne, partTwo);
    }

    private static string GetSample(int year, int day)
        => (year, day) switch
        {
            (2024, 1) => Samples2024.Day1,
            (2024, 2) => Samples2024.Day2,
            (2024, 3) => Samples2024.Day3,
            (2024, 4) => Samples2024.Day4,
            (2024, 5) => Samples2024.Day5,
            (2024, 6) => Samples2024.Day6,
            (2024, 7) => Samples2024.Day7,
            (2024, 8) => Samples2024.Day8,
            (2024, 9) => Samples2024.Day9,
            (2024, 10) => Samples2024.Day10,
            (2024, 11) => Samples2024.Day11,
            (2024, 12) => Samples2024.Day12,
            (2024, 13) => Samples2024.Day13,
            (2024, 14) => Samples2024.Day14,
            (2024, 15) => Samples2024.Day15,
            (2024, 16) => Samples2024.Day16,
            (2024, 17) => Samples2024.Day17,
            (2024, 18) => Samples2024.Day18,
            (2024, 19) => Samples2024.Day19,
            (2024, 20) => Samples2024.Day20,
            (2024, 21) => Samples2024.Day21,
            (2024, 22) => Samples2024.Day22,
            (2024, 23) => Samples2024.Day23,
            (2024, 24) => Samples2024.Day24,
            (2024, 25) => Samples2024.Day25,
            _ => string.Empty
        };

    private static (long, long) ExecuteSolution(int year, int day, string input)
        => (year, day) switch
        {
            (2015, 1) => Solution2015.Day1(input),
            (2015, 2) => Solution2015.Day2(input),
            (2015, 3) => Solution2015.Day3(input),
            (2015, 4) => Solution2015.Day4(input),
            (2024, 1) => Solution2024.Day1(input),
            (2024, 2) => Solution2024.Day2(input),
            (2024, 3) => Solution2024.Day3(input),
            (2024, 4) => Solution2024.Day4(input),
            (2024, 5) => Solution2024.Day5(input),
            (2024, 6) => Solution2024.Day6(input),
            (2024, 7) => Solution2024.Day7(input),
            (2024, 8) => Solution2024.Day8(input),
            (2024, 9) => Solution2024.Day9(input),
            (2024, 10) => Solution2024.Day10(input),
            (2024, 11) => Solution2024.Day11(input),
            (2024, 12) => Solution2024.Day12(input),
            (2024, 13) => Solution2024.Day13(input),
            (2024, 14) => Solution2024.Day14(input),
            (2024, 15) => Solution2024.Day15(input),
            (2024, 16) => Solution2024.Day16(input),
            (2024, 17) => Solution2024.Day17(input),
            (2024, 18) => Solution2024.Day18(input),
            (2024, 19) => Solution2024.Day19(input),
            (2024, 20) => Solution2024.Day20(input),
            (2024, 21) => Solution2024.Day21(input),
            (2024, 22) => Solution2024.Day22(input),
            (2024, 23) => Solution2024.Day23(input),
            (2024, 24) => Solution2024.Day24(input),
            (2024, 25) => Solution2024.Day25(input),
            _ => (0, 0)
        };
}
