using AdventOfCode.Solutions;

Console.WriteLine("Enter a day (1-25) for Advent of Code 2025 (press Enter for current day):");
var input = Console.ReadLine();
var day = string.IsNullOrEmpty(input) ? DateTime.Now.Day : int.Parse(input);

if (day < 1 || day > 25)
{
    Console.WriteLine("Day must be between 1 and 25!");
    return;
}

Console.WriteLine($"Enter input for Day {day} of Advent of Code 2025:");
var puzzleInput = Console.ReadLine() ?? "";

var result = day switch
{
    1 => Solutions2025.Day1(puzzleInput),
    2 => Solutions2025.Day2(puzzleInput),
    _ => (0, 0) // Default case for unsupported days
};

Console.WriteLine($"Part 1: {result.Item1}");
Console.WriteLine($"Part 2: {result.Item2}");
