using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions2024;

public static partial class Solutions2024
{
    public static (int, int) Day3(string input)
    {
        static int multiplyMatches(Match match)
            => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);

        var regex = new Regex("""mul\((\d+),(\d+)\)""");

        var partOne = 0;
        foreach (Match match in regex.Matches(input))
        {
            partOne += multiplyMatches(match);
        }

        var partTwo = 0;
        foreach (var doo in input.Split("do()"))
        {
            foreach (Match match in regex.Matches(doo.Split("don't()").FirstOrDefault() ?? string.Empty))
            {
                partTwo += multiplyMatches(match);
            }
        }

        return (partOne, partTwo);
    }
}
