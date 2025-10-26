namespace AdventOfCode.Solutions2025;

public static class Day00
{
    public static ((int Part1, int Part2) Sample, (int Part1, int Part2) Input) Solve()
    {
        var sample = """
            1 2 3
            4 5 6
            """;

        var splitSample = sample.SplitByLine();
        var input = File.ReadAllLines(GetInputFilePath("00"));

        return ((Part1(splitSample), Part2(splitSample)), (Part1(input), Part2(input)));
    }

    private static int Part1(string[] input)
    {
        return input
            .SelectMany(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse))
            .Count();
    }

    private static int Part2(string[] input)
    {
        return input
            .SelectMany(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse))
            .Sum();
    }
}
