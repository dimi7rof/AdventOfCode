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
}
