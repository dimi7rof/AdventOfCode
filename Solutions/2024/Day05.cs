namespace AdventOfCode.Solutions;

public static partial class Solutions2024
{
    public static (int, int) Day5(string input)
    {
        int partOne = 0, partTwo = 0;
        var arr = input.Split(Environment.NewLine);
        var firstPart = arr.Where(x => x.Contains('|')).ToArray();
        var secondPart = arr.Where(x => x.Contains(',')).ToArray();
        var order = new List<int>()
        {
            firstPart.First().Split('|').Select(int.Parse).First(),
            firstPart.First().Split('|').Select(int.Parse).Last()
        };
        foreach (var row in firstPart)
        {
            var ints = row.Split(',').Select(int.Parse).ToArray();
            var index = Array.IndexOf(ints, row.First());
            order.Insert(index + 1, row.Last());
        }

        var unordered = new List<int[]>();
        foreach (var row in secondPart)
        {
            var ints = row.Split(',').Select(int.Parse).ToArray();

            var array = firstPart
                    .Select(x => x.Split('|'))
                    .Select(x => (int.Parse(x.First()), int.Parse(x.Last())))
                    .Where(x => ints.Contains(x.Item1) && ints.Contains(x.Item2))
                    .ToArray();
            var isValid = true;
            foreach (var (s, b) in array)
            {
                if (ints.Index().Where(x => x.Item == s).Select(x => x.Index).Single() <
                    ints.Index().Where(x => x.Item == b).Select(x => x.Index).Single())
                {
                    continue;
                }
                else
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
            {
                partOne += ints[ints.Length / 2];
                continue;
            }
            unordered.Add(ints);
        }


        foreach (var row in unordered)
        {
            var ordered = false;
            while (ordered)
            {
                for (var i = 0; i < row.Length - 1; i++)
                {

                }
            }
        }

        return (partOne, partTwo);
    }
}
