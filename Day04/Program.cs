namespace Day04;

internal static class Day04
{
    public static void Main(string[] args)
    {
        const string inputFile = "input.txt";

        Console.WriteLine("Day03!");

        List<string> lines = [];

        try
        {
            StreamReader sr = new(inputFile);
            string? line = sr.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = sr.ReadLine();
            }

            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        if (args.Length != 1)
        {
            Console.WriteLine("Usage: Day01 <part 1/2>");
            return;
        }

        string input = args[0];
        int day = int.Parse(input);
        switch (day)
        {
            case 1:
                Part1(lines);
                break;
            case 2:
                Part2(lines);
                break;
            default:
                Console.WriteLine("Usage: Day01 <part 1/2");
                break;
        }
    }

    private static void Part1(List<string> lines)
    {
        Console.WriteLine("Part 1");

        List<List<char>> grid = []; // y,x


        for (int y = 0; y < lines.Count; y++)
        {
            string line = lines[y];
            grid.Add([]);
            for (int x = 0; x < line.Length; x++)
            {
                grid[y].Add(line[x]);

            }
        }

        int sum = 0;

        for (int y = 0; y < grid.Count; y++)
        {
            var row = grid[y];
            for (int x = 0; x < row.Count; x++)
            {

                char value = row[x];

                if (value != 'X')
                {
                    continue;
                }

                // forwards horizontal
                if (x >= 0 && x <= row.Count - 4)
                {
                    if (row[x + 1] == 'M' && row[x + 2] == 'A' && row[x + 3] == 'S')
                    {
                        sum++;
                    }
                }
                // backwards horizontal
                if (x >= 3 && x <= row.Count)
                {
                    if (row[x - 1] == 'M' && row[x - 2] == 'A' && row[x - 3] == 'S')
                    {
                        sum++;
                    }
                }

                // forwards vertical
                if (y >= 0 && y <= grid.Count - 4)
                {
                    if (grid[y + 1][x] == 'M' && grid[y + 2][x] == 'A' && grid[y + 3][x] == 'S')
                    {
                        sum++;
                    }
                }

                // backwards vertical
                if (y >= 3 && y <= grid.Count)
                {
                    if (grid[y - 1][x] == 'M' && grid[y - 2][x] == 'A' && grid[y - 3][x] == 'S')
                    {
                        sum++;
                    }
                }

                // down-right
                if (x >= 0 && x <= row.Count - 4 && y >= 0 && y <= grid.Count - 4)
                {
                    if (grid[y + 1][x + 1] == 'M' && grid[y + 2][x + 2] == 'A' && grid[y + 3][x + 3] == 'S')
                    {
                        sum++;
                    }

                }

                // down-left
                if (x >= 3 && x <= row.Count && y >= 0 && y <= grid.Count - 4)
                {
                    if (grid[y + 1][x - 1] == 'M' && grid[y + 2][x - 2] == 'A' && grid[y + 3][x - 3] == 'S')
                    {
                        sum++;
                    }

                }

                // up-right
                if (x >= 0 && x <= row.Count - 4 && y >= 3 && y <= grid.Count)
                {
                    if (grid[y - 1][x + 1] == 'M' && grid[y - 2][x + 2] == 'A' && grid[y - 3][x + 3] == 'S')
                    {
                        sum++;
                    }

                }

                // up-left
                if (x >= 3 && x <= row.Count && y >= 3 && y <= grid.Count)
                {
                    if (grid[y - 1][x - 1] == 'M' && grid[y - 2][x - 2] == 'A' && grid[y - 3][x - 3] == 'S')
                    {
                        sum++;
                    }

                }

            }
        }
        Console.WriteLine(sum);
    }

    private static void Part2(List<string> lines)
    {
        Console.WriteLine("Part 2");

        List<List<char>> grid = []; // y,x


        for (int y = 0; y < lines.Count; y++)
        {
            string line = lines[y];
            grid.Add([]);
            for (int x = 0; x < line.Length; x++)
            {
                grid[y].Add(line[x]);

            }
        }

        int sum = 0;

        for (int y = 0; y < grid.Count; y++)
        {
            var row = grid[y];
            for (int x = 0; x < row.Count; x++)
            {

                // char value = row[x];

                // if (value != 'X')
                // {
                //     continue;
                // }

                // // forwards horizontal
                // if (x >= 0 && x <= row.Count - 4)
                // {
                //     if (row[x + 1] == 'M' && row[x + 2] == 'A' && row[x + 3] == 'S')
                //     {
                //         sum++;
                //     }
                // }
                // // backwards horizontal
                // if (x >= 3 && x <= row.Count)
                // {
                //     if (row[x - 1] == 'M' && row[x - 2] == 'A' && row[x - 3] == 'S')
                //     {
                //         sum++;
                //     }
                // }

                // // forwards vertical
                // if (y >= 0 && y <= grid.Count - 4)
                // {
                //     if (grid[y + 1][x] == 'M' && grid[y + 2][x] == 'A' && grid[y + 3][x] == 'S')
                //     {
                //         sum++;
                //     }
                // }

                // // backwards vertical
                // if (y >= 3 && y <= grid.Count)
                // {
                //     if (grid[y - 1][x] == 'M' && grid[y - 2][x] == 'A' && grid[y - 3][x] == 'S')
                //     {
                //         sum++;
                //     }
                // }

                // // down-right
                // if (x >= 0 && x <= row.Count - 4 && y >= 0 && y <= grid.Count - 4)
                // {
                //     if (grid[y + 1][x + 1] == 'M' && grid[y + 2][x + 2] == 'A' && grid[y + 3][x + 3] == 'S')
                //     {
                //         sum++;
                //     }

                // }

                // // down-left
                // if (x >= 3 && x <= row.Count && y >= 0 && y <= grid.Count - 4)
                // {
                //     if (grid[y + 1][x - 1] == 'M' && grid[y + 2][x - 2] == 'A' && grid[y + 3][x - 3] == 'S')
                //     {
                //         sum++;
                //     }

                // }

                // // up-right
                // if (x >= 0 && x <= row.Count - 4 && y >= 3 && y <= grid.Count)
                // {
                //     if (grid[y - 1][x + 1] == 'M' && grid[y - 2][x + 2] == 'A' && grid[y - 3][x + 3] == 'S')
                //     {
                //         sum++;
                //     }

                // }

                // // up-left
                // if (x >= 3 && x <= row.Count && y >= 3 && y <= grid.Count)
                // {
                //     if (grid[y - 1][x - 1] == 'M' && grid[y - 2][x - 2] == 'A' && grid[y - 3][x - 3] == 'S')
                //     {
                //         sum++;
                //     }

                // }

            }
        }
        Console.WriteLine(sum);
    }
}