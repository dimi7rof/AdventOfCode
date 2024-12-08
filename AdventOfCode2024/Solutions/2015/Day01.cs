using Microsoft.Extensions.Primitives;

namespace AdventOfCode.Solutions;

public static partial class Solutions2015
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
            floor = value[i] == '(' ? floor++ : floor--;
            if (floor == -1)
            {
                partTwo = i;
                break;
            }
        }

        return (partOne, partTwo);
    }
}
