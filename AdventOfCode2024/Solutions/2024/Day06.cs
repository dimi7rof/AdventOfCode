using System.Collections.Concurrent;

namespace AdventOfCode.Solutions;

public static partial class Solutions2024
{
    public static (int, int) Day6(string input)
    {
        var arr = input.Split(Environment.NewLine);

        var cleanField = new char[arr.Length, arr.First().Length];
        (int X, int Y) pos = (0, 0);
        var partOne = 0;
        for (int y = 0; y < arr.First().Length; y++)
        {
            for (int x = 0; x < arr.Length; x++)
            {
                cleanField[x, y] = arr[x][y];
                if (arr[x][y] == '^')
                {
                    pos = (x, y);
                }
            }
        }

        static bool IsOut(int x, int y, char[,] arr, char direction)
        {
            if (direction == '^' && x == 0) return true;
            else if (direction == '<' && y == 0) return true;
            else if (direction == 'v' && x == arr.GetLength(1) - 1) return true;
            else if (direction == '>' && y == arr.GetLength(0) - 1) return true;
            return false;
        };
        var field = new char[arr.Length, arr.First().Length];
        Array.Copy(cleanField, field, arr.Length * arr.First().Length);
        while (true)
        {
            if (field[pos.X, pos.Y] == '^')
            {
                field[pos.X, pos.Y] = 'X';
                if (field[pos.X - 1, pos.Y] != '#')
                {
                    pos = (pos.X - 1, pos.Y);
                    field[pos.X, pos.Y] = '^';
                }
                else
                {
                    pos = (pos.X, pos.Y + 1);
                    field[pos.X, pos.Y] = '>';
                }

                if (IsOut(pos.X, pos.Y, field, field[pos.X, pos.Y])) { break; }
            }
            else if (field[pos.X, pos.Y] == '>')
            {
                field[pos.X, pos.Y] = 'X';
                if (field[pos.X, pos.Y + 1] != '#')
                {
                    pos = (pos.X, pos.Y + 1);
                    field[pos.X, pos.Y] = '>';
                }
                else
                {
                    pos = (pos.X + 1, pos.Y);
                    field[pos.X, pos.Y] = 'v';
                }

                if (IsOut(pos.X, pos.Y, field, field[pos.X, pos.Y])) { break; }
            }
            else if (field[pos.X, pos.Y] == 'v')
            {
                field[pos.X, pos.Y] = 'X';
                if (field[pos.X + 1, pos.Y] != '#')
                {
                    pos = (pos.X + 1, pos.Y);
                    field[pos.X, pos.Y] = 'v';
                }
                else
                {
                    pos = (pos.X, pos.Y - 1);
                    field[pos.X, pos.Y] = '<';
                }

                if (IsOut(pos.X, pos.Y, field, field[pos.X, pos.Y])) { break; }
            }
            else if (field[pos.X, pos.Y] == '<')
            {
                field[pos.X, pos.Y] = 'X';
                if (field[pos.X, pos.Y - 1] != '#')
                {
                    pos = (pos.X, pos.Y - 1);
                    field[pos.X, pos.Y] = '<';
                }
                else
                {
                    pos = (pos.X - 1, pos.Y);
                    field[pos.X, pos.Y] = '^';
                }

                if (IsOut(pos.X, pos.Y, field, field[pos.X, pos.Y])) { break; }
            }
            //PrintField(field);
        }
        field[pos.X, pos.Y] = 'X';

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == 'X')
                {
                    partOne++;
                }
            }
        }

        var partTwo = 0;
        Console.WriteLine(DateTime.Now);

        var mazes = new List<(char[,], (int X, int Y, char dir))>();
        var maze = new char[arr.Length, arr.First().Length];
        Array.Copy(cleanField, maze, arr.Length * arr.First().Length);
        (int X, int Y, char dir) pos2 = (0, 0, '^');
        for (int a = 0; a < arr.First().Length; a++)
        {
            for (int b = 0; b < arr.Length; b++)
            {
                //maze[b, a] = arr[b][a];
                if (arr[b][a] == '^')
                {
                    pos2 = (b, a, '^');
                }
            }
        }

        for (int row = 0; row < arr.First().Length; row++)
        {
            for (int col = 0; col < arr.Length; col++)
            {
                var newMaze = new char[arr.Length, arr.First().Length];
                Array.Copy(maze, newMaze, arr.Length * arr.First().Length);
                if (col != pos2.X || row != pos2.Y)
                {
                    maze[col, row] = '#';
                }
                if (field[col, row] == 'X')
                {
                    mazes.Add((newMaze, pos2));
                    PrintField(maze);
                    PrintField(newMaze);
                }
            }
        }

        var bag = new ConcurrentBag<int>();
        foreach (var item in mazes)
        {
            var maze0 = item.Item1;
            //var pos2 = run.Item2;
            var history = new HashSet<(int X, int Y, char dir)>();
            var isInLoop = false;

            while (!isInLoop)
            {
                PrintPartlyField(maze0, pos2.X, pos2.Y);
                if (maze0[pos2.X, pos2.Y] == '^')
                {
                    maze0[pos2.X, pos2.Y] = 'X';
                    if (maze0[pos2.X - 1, pos2.Y] != '#')
                    {
                        pos2 = (pos2.X - 1, pos2.Y, '^');
                        maze0[pos2.X, pos2.Y] = '^';
                    }
                    else
                    {
                        pos2 = (pos2.X, pos2.Y + 1, '>');
                        maze0[pos2.X, pos2.Y] = '>';
                    }
                }
                else if (maze0[pos2.X, pos2.Y] == '>')
                {
                    maze0[pos2.X, pos2.Y] = 'X';
                    if (maze0[pos2.X, pos2.Y + 1] != '#')
                    {
                        pos2 = (pos2.X, pos2.Y + 1, '>');
                        maze0[pos2.X, pos2.Y] = '>';
                    }
                    else
                    {
                        pos2 = (pos2.X + 1, pos2.Y, 'v');
                        maze0[pos2.X, pos2.Y] = 'v';
                    }
                }
                else if (maze0[pos2.X, pos2.Y] == 'v')
                {
                    maze0[pos2.X, pos2.Y] = 'X';
                    if (maze0[pos2.X + 1, pos2.Y] != '#')
                    {
                        pos2 = (pos2.X + 1, pos2.Y, 'v');
                        maze0[pos2.X, pos2.Y] = 'v';
                    }
                    else
                    {
                        pos2 = (pos2.X, pos2.Y - 1, '<');
                        maze0[pos2.X, pos2.Y] = '<';
                    }
                }
                else if (maze0[pos2.X, pos2.Y] == '<')
                {
                    maze0[pos2.X, pos2.Y] = 'X';
                    if (maze0[pos2.X, pos2.Y - 1] != '#')
                    {
                        pos2 = (pos2.X, pos2.Y - 1, '<');
                        maze0[pos2.X, pos2.Y] = '<';
                    }
                    else
                    {
                        pos2 = (pos2.X - 1, pos2.Y, '^');
                        maze0[pos2.X, pos2.Y] = '^';
                    }
                }
                if (IsOut(pos2.X, pos2.Y, maze0, maze0[pos2.X, pos2.Y])) { break; }
                if (history.Any(x => x.X == pos2.X && x.Y == pos2.Y && x.dir == pos2.dir))
                {
                    isInLoop = true;
                    bag.Add(0);
                    Console.WriteLine($"Found position {bag.Count}, coordinates: {pos2}");
                }
                history.Add((pos2.X, pos2.Y, pos2.dir));
            }
        }
        Parallel.ForEach(mazes, run =>
        {

        });
        Console.WriteLine(DateTime.Now);
        partTwo = bag.Count;
        return (partOne, partTwo);
        //4514 <
    }
}
