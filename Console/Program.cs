using AdventOfCode.Solutions2025;
using System.Diagnostics;

var start = Stopwatch.GetTimestamp();

var day = DateTime.Now.Day;
var (sample, result) = day switch
{
    1 => Day01.Solve(),
    2 => Day02.Solve(),
    3 => Day03.Solve(),
    4 => Day04.Solve(),
    5 => Day05.Solve(),
    6 => Day06.Solve(),
    7 => Day07.Solve(),
    8 => Day08.Solve(),
    9 => Day09.Solve(),
    10 => Day10.Solve(),
    11 => Day11.Solve(),
    12 => Day12.Solve(),
    13 => Day13.Solve(),
    14 => Day14.Solve(),
    15 => Day15.Solve(),
    16 => Day16.Solve(),
    17 => Day17.Solve(),
    18 => Day18.Solve(),
    19 => Day19.Solve(),
    20 => Day20.Solve(),
    21 => Day21.Solve(),
    22 => Day22.Solve(),
    23 => Day23.Solve(),
    24 => Day24.Solve(),
    25 => Day25.Solve(),
    _ => Day00.Solve()
};

Console.WriteLine($"Sample: Part 1: {sample.Part1}");
Console.WriteLine($"Sample: Part 2: {sample.Part2}");
Console.WriteLine($"Result: Part 1: {result.Part1}");
Console.WriteLine($"Result: Part 2: {result.Part2}");

var end = Stopwatch.GetTimestamp();
var elapsedMs = (end - start) / (double)Stopwatch.Frequency;
Console.WriteLine($"Elapsed time: {elapsedMs:F2} s");