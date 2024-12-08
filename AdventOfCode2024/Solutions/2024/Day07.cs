namespace AdventOfCode.Solutions;

public static partial class Solutions2024
{
    public static (long, long) Day7(string input)
    {
        var rows = input.Split(Environment.NewLine);
        long partOne = 0;

        static bool CheckAddOrMultiply(long expected, int[] arr, int index, long result)
            => index == arr.Length
                ? result == expected
                : CheckAddOrMultiply(expected, arr, index + 1, result + arr[index]) ||
                  CheckAddOrMultiply(expected, arr, index + 1, result * arr[index]);
        
        foreach (var row in rows)
        {
            var parts = row.Split(':').ToArray();
            var expected = long.Parse(parts.First());
            var array = parts.Last()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (CheckAddOrMultiply(expected, array, 0, 0))
            {
                partOne += expected;
            }

        }

        long partTwo = 0;

        static List<long> GetPossibleResults(int[] array, int index, List<long> listOfResults)
        {
            var newResults = new List<long>();
            newResults.AddRange(listOfResults.Select(x => x + array[index]));
            newResults.AddRange(listOfResults.Select(x => x * array[index]));
            newResults.AddRange(listOfResults.Select(x => long.Parse($"{array[index]}{x}")));
            if (index == 0)
            {
                return newResults;
            }
            return GetPossibleResults(array, index - 1, newResults);
        }

        foreach (var row in rows)
        {
            var parts = row.Split(':').ToArray();
            var expected = long.Parse(parts.First());
            var array = parts.Last()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var concatenateResults = new List<int[]>();
            for (int i = 0; i < array.Length; i++)
            {

            }
            var results = GetPossibleResults(array, array.Length - 2, [array[^1]]);
            if (results.Any(x => x == expected))
            {
                partTwo += expected;
            }

        }
        return (partOne, partTwo);
        //20281182715321
    }
}
