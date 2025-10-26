namespace AdventOfCode.Solutions2025;

public static class Day17
{
    private readonly static string _sample = """
        
        """;

    public static ((int Part1, int Part2) Sample, (int Part1, int Part2) Input) Solve()
    {
        var splitSample = _sample.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var input = File.ReadAllLines(GetInputFilePath("17"));

        return ((Part1(splitSample), Part2(splitSample)), (Part1(input), Part2(input)));
    }

    private static int Part1(string[] input)
    {
        var result = 0;
        return result;
    }

    private static int Part2(string[] input)
    {
        var result = 0;
        return result;
    }
}
