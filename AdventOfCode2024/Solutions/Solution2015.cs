using Microsoft.Extensions.Primitives;

namespace AdventOfCode.Solutions;

public static class Solution2015
{
    public static (int, int) Day1(StringValues input)
    {
        var value = input
            .First()!
            .Split(Environment.NewLine)
            .First();

        var partOne = value.Count(x => x == '(') - value.Count(x => x == ')');

        var partTwo = 0;
        var floor = 0;
        for (var i = 1; i <= value.Length; i++)
        {
            if (value[i] == '(')
            {
                floor++;
            }
            else
            {
                floor--;
            }
            if (floor == -1)
            {
                partTwo = i;
                break;
            }
        }

        return (partOne, partTwo);
    }

    public static (int, int) Day2(StringValues input)
    {
        var presents = input
            .First()!
            .Split(Environment.NewLine)
            .Select(x => x
                .Split('x')
                .Select(x => int.Parse(x))
                .ToArray());

        var partOne = presents
            .Select(x => new
                {
                    L = x[0],
                    W = x[1],
                    H = x[2]
                })
            .Select(x => new
                {
                    A = x.L * x.W,
                    B = x.L * x.H,
                    C = x.W * x.H
                })
            .Select(x => ((x.A + x.B + x.C) * 2) + new int[] { x.A, x.B, x.C }.Min())
            .Sum();

        var partTwo = presents
            .Select(x => (x[0] * x[1] * x[2]) + (x.OrderBy(y => y).Take(2).Sum() * 2))
            .Sum();

        return (partOne, partTwo);
    }

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
