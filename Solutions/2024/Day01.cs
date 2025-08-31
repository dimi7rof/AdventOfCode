namespace AdventOfCode.Solutions;

public static partial class Solutions2024
{
    public static (int, int) Day1(string input)
    {
        var values = input.Split(Environment.NewLine)
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries));

        //part1
        var firstList = values
            .Select(x => int.Parse(x.First()))
            .Order();

        var secondList = values
            .Select(x => int.Parse(x.Last()))
            .Order();

        var partOne = firstList
            .Zip(secondList, (x, y) => Math.Abs(x - y))
            .Sum();

        //part2
        var countDictionary = secondList
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        var partTwo = firstList
            .Sum(item => item * (countDictionary.TryGetValue(item, out int value) ? value : 0));

        return (partOne, partTwo);
    }
}
