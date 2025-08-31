namespace AdventOfCode.Solutions;

public static partial class Solutions2024
{
    public static (int, int) Day4(string input)
    {
        var arr = input.Split(Environment.NewLine);

        var partOne = 0;
        for (int y = 0; y < arr.First().Length; y++)
        {
            for (int x = 0; x < arr.Length; x++)
            {
                if (y < arr.First().Length - 3)
                {
                    var down = string.Concat(arr[y][x], arr[y + 1][x], arr[y + 2][x], arr[y + 3][x]);
                    if (down is "XMAS" or "SAMX") { partOne++; };
                }

                if (x < arr.Length - 3)
                {
                    var right = string.Concat(arr[y][x], arr[y][x + 1], arr[y][x + 2], arr[y][x + 3]);
                    if (right is "XMAS" or "SAMX") { partOne++; };
                }

                if (x >= 3 && y < arr.First().Length - 3)
                {
                    var d2 = string.Concat(arr[y][x], arr[y + 1][x - 1], arr[y + 2][x - 2], arr[y + 3][x - 3]);
                    if (d2 is "XMAS" or "SAMX") { partOne++; };
                }

                if (x < arr.Length - 3 && y < arr.First().Length - 3)
                {
                    var d1 = string.Concat(arr[y][x], arr[y + 1][x + 1], arr[y + 2][x + 2], arr[y + 3][x + 3]);
                    if (d1 is "XMAS" or "SAMX") { partOne++; };
                }
            }
        }

        var partTwo = 0;
        for (int y = 1; y < arr.First().Length - 1; y++)
        {
            for (int x = 1; x < arr.Length - 1; x++)
            {
                var current = arr[y][x];
                if (current is not 'A') { continue; }
                var d1 = string.Concat(arr[y - 1][x + 1], current, arr[y + 1][x - 1]);
                var d2 = string.Concat(arr[y + 1][x + 1], current, arr[y - 1][x - 1]);
                if (d1 is "MAS" or "SAM" && d2 is "MAS" or "SAM")
                {
                    partTwo++;
                }
            }
        }

        return (partOne, partTwo);
    }
}
