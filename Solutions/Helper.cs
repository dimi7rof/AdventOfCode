using System.Reflection;

namespace AdventOfCode.Solutions;

internal static class Helper
{
    private static readonly string[] _root =
        [.. Assembly.GetExecutingAssembly().Location.Split(Path.DirectorySeparatorChar).SkipLast(5)];

    internal static string GetInputFilePath(string day)
        => Path.Combine(Path.Combine(_root), "Solutions", "Inputs", "2025", $"{day}.txt");

    internal static string[] SplitByLine(this string input)
        => [.. input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)];

    internal static string[] SplitBySpace(this string input)
        => [.. input.Split(' ', StringSplitOptions.RemoveEmptyEntries)];
}
