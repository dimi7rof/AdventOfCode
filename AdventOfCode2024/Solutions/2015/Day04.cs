using Microsoft.Extensions.Primitives;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Solutions;

public static partial class Solution2015
{

    public static (int, int) Day4(StringValues input)
    {
        var value = input.FirstOrDefault();

        int partOne = 0;
        var counter = 0;
        while (true)
        {
            var hashBytes = MD5.HashData(Encoding.UTF8.GetBytes(value + counter));

            var hash = string.Concat(hashBytes.Select(b => b.ToString("x2")));

            if (hash.StartsWith("00000"))
            {
                partOne = partOne == 0 ? counter : partOne;
            }
            if (hash.StartsWith("000000"))
            {
                break;
            }
            counter++;
        }

        return (partOne, counter);
    }
}
