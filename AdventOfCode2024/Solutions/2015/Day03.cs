using Microsoft.Extensions.Primitives;

namespace AdventOfCode.Solutions;

public static partial class Solutions2015
{

    public static (int, int) Day3(StringValues input)
    {
        var moves = input.First()!;

        //Part1
        var field = new int[1000, 1000];
        int santaX = 500, santaZ = 500;
        field[santaX, santaZ] = 1;

        var directions = new Dictionary<char, (int dx, int dz)>
        {
            { '^', (-1, 0) },
            { 'v', (1, 0) },
            { '<', (0, -1) },
            { '>', (0, 1) }
        };

        foreach (var move in moves)
        {
            var (dx, dz) = directions[move];
            santaX += dx;
            santaZ += dz;
            field[santaX, santaZ]++;
        }

        var partOne = field.Cast<int>().Count(x => x > 0);

        //Part2
        var field2 = new int[1000, 1000];
        santaX = 500;
        santaZ = 500;
        int roboX = 500, roboZ = 500;
        field2[santaX, santaZ] = 1;

        for (int i = 0; i < moves.Length; i++)
        {
            var (dx, dz) = directions[moves[i]];

            if (i % 2 == 0)
            {
                santaX += dx;
                santaZ += dz;
                field2[santaX, santaZ]++;
            }
            else
            {
                roboX += dx;
                roboZ += dz;
                field2[roboX, roboZ]++;
            }
        }

        var partTwo = field2.Cast<int>().Count(x => x > 0);

        return (partOne, partTwo);
    }
}
