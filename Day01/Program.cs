namespace Day01;

class DuplicateValuesComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (y == x)
        {
            // assume greater for so that duplicate values can be used
            return 1;
        }

        return x - y;
    }
}

internal static class Day01
{
    public static void Main(string[] args)
    {
        const string inputFile = "input.txt";

        Console.WriteLine("Day01!");

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

        SortedList<int, int> leftList = new(new DuplicateValuesComparer());
        SortedList<int, int> rightList = new(new DuplicateValuesComparer());

        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");

            int leftValue = int.Parse(parts[0]);
            leftList.Add(leftValue, leftValue);

            int rightValue = int.Parse(parts[1]);
            rightList.Add(rightValue, rightValue);
        }

        var zippedList = leftList.Values.Zip(rightList.Values, (left, right) =>
            new Tuple<int, int>(left, right));

        int result = 0;
        foreach (var pair in zippedList)
        {
            result += int.Abs(pair.Item1 - pair.Item2);
        }

        Console.WriteLine(result);
    }

    private static void Part2(List<string> lines)
    {
        Console.WriteLine("Part 2");

        Dictionary<int, int> leftCounter = new Dictionary<int, int>();
        Dictionary<int, int> rightCounter = new Dictionary<int, int>();

        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");

            int leftValue = int.Parse(parts[0]);
            if (!leftCounter.TryAdd(leftValue, 1))
            {
                leftCounter[leftValue] += 1;
            }

            int rightValue = int.Parse(parts[1]);
            if (!rightCounter.TryAdd(rightValue, 1))
            {
                rightCounter[rightValue] += 1;
            }
        }

        int result = 0;
        foreach (KeyValuePair<int, int> leftKeyValue in leftCounter)
        {
            rightCounter.TryGetValue(leftKeyValue.Key, out int rightValue);
            result += leftKeyValue.Key * rightValue * leftKeyValue.Value;
        }

        Console.WriteLine(result);
    }
}