namespace AdventOfCode.Solutions;

public static partial class Solutions2024
{
    public static (int, int) Day2(string input)
    {
        var rows = input.Split(Environment.NewLine);

        static int[] getDifferences(int[] array) =>
            array.Zip(array.Skip(1), (a, b) => a - b).ToArray();

        static bool isValid(int[] array) =>
            (!array.Any(x => Math.Abs(x) > 3) &&
            (array.All(x => x > 0) || array.All(x => x < 0)));

        int partOne = 0, partTwo = 0;
        foreach (var row in rows)
        {
            var intArray = row
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (isValid(getDifferences(intArray)))
            {
                partOne++;
                partTwo++;
                continue;
            }

            if (intArray
                .Select((t, i) => intArray.Where((_, index) => index != i))
                .Any(x => isValid(getDifferences(x.ToArray()))))
            {
                partTwo++;
            }
        }

        return (partOne, partTwo);
    }
}
