using AdventOfCode.Solutions;

Console.WriteLine("Enter a day (1-25) for Advent of Code 2025:");
var day = int.Parse(Console.ReadLine() ?? "1");

Console.WriteLine($"Enter input for Day {day} of Advent of Code 2025:");
var input = Console.ReadLine() ?? "";

var result = day switch
{
    1 => Solutions2025.Day1(input),
    2 => Solutions2025.Day2(input),
    _ => (0, 0) // Default case for unsupported days
};

Console.WriteLine($"Part 1: {result.Item1}");
Console.WriteLine($"Part 2: {result.Item2}");