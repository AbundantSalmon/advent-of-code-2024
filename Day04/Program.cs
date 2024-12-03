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

    }

    private static void Part2(List<string> lines)
    {
        Console.WriteLine("Part 2");

    }
}