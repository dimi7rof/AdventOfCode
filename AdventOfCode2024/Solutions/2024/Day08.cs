namespace AdventOfCode.Solutions;

public static partial class Solutions2024
{
    public static (int, int) Day8(string input)
    {
        var arr = input.Split(Environment.NewLine);
        var partOne = 0;

        var listOfAntenas = new HashSet<(int, int, char)>();
        var field = CreateCharArray(arr);
        var rows = field.GetLength(0);
        var cols = field.GetLength(1);
        var initialField = new char[rows, cols];
        Array.Copy(field, initialField, rows * cols);
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                var current = field[col, row];
                if (current == '.') continue;
                listOfAntenas.Add((col, row, current));
            }
        }
        var grouped = listOfAntenas
            .GroupBy(x => x.Item3)
            .ToDictionary(x => x.Key, x => x.Select(x => (x.Item1, x.Item2)));

        foreach (var (ch, sameFriquency) in grouped)
        {
            var end = false;
            foreach (var ant1 in sameFriquency)
            {
                foreach (var ant2 in sameFriquency
                    .Where(x => x.Item1 != ant1.Item1 && x.Item2 != ant1.Item2))
                {
                    var distance1 = ant1.Item1 - ant2.Item1;
                    var distance2 = ant1.Item2 - ant2.Item2;

                    var firstAntinodeX = ant1.Item1 + distance1;
                    var firstAntinodeY = ant1.Item2 + distance2;
                    var secondAntinodeX = ant2.Item1 - distance1;
                    var secondAntinodeY = ant2.Item2 - distance2;
                    try
                    {
                        if (field[firstAntinodeX, firstAntinodeY] == '.')
                        {
                            field[firstAntinodeX, firstAntinodeY] = ch;
                        }
                        else if (field[firstAntinodeX, firstAntinodeY] == ch) { continue; }
                        else if (initialField[firstAntinodeX, firstAntinodeY] == '.')
                        {
                            //end = true;
                            //break;
                        }
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        if (field[secondAntinodeX, secondAntinodeY] == '.')
                        {
                            field[secondAntinodeX, secondAntinodeY] = ch;
                        }
                        else if (field[secondAntinodeX, secondAntinodeY] == ch) { continue; }
                        else if (initialField[secondAntinodeX, secondAntinodeY] == '.')
                        {
                            //end = true;
                            //break;
                        }
                    }
                    catch (Exception)
                    {

                    }
                    PrintField(field);
                }
                if (end) break;
            }
            if (end) break;
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (field[col, row] != initialField[col, row])
                {
                    partOne++;
                }
            }
        }

        var partTwo = 0;
        return (partOne, partTwo);
        //291<
    }

    private static char[,] lastField = new char[10, 10];

    internal static void PrintField(char[,] field)
    {

        Thread.Sleep(250);
        Console.Clear();
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (lastField is not null)
                {
                    var a = lastField[i, j];
                    var b = field[i, j];
                    if (a != b)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                Console.Write(field[i, j]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
        Array.Copy(field, lastField, field.GetLength(0) * field.GetLength(1));
    }

    internal static void PrintPartlyField(char[,] field, int x, int y)
    {
        Thread.Sleep(250);
        Console.Clear();
        var min = x - 7 < 0 ? 0 : x - 7;
        var max = x + 7 > field.GetLength(0) ? field.GetLength(0) : x + 7;
        for (int i = min; i < max; i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
    }

    internal static char[,] CreateCharArray(string[] input)
    {
        var field = new char[input.Length, input.First().Length];
        for (int y = 0; y < input.First().Length; y++)
        {
            for (int x = 0; x < input.Length; x++)
            {
                field[x, y] = input[x][y];
            }
        }
        return field;
    }
}
