namespace Day07;

internal static class Day07
{
    public static void Main(string[] args)
    {
        const string inputFile = "input.txt";

        Console.WriteLine("Day07!");

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

    enum Operators
    {
        Add,
        Multiple,
        Concatenate
    }

    private static void Part1(List<string> lines)
    {
        Console.WriteLine("Part 1");

        long sum = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split(":");
            var expectedResult = long.Parse(parts[0]);


            string[] valuesStrings = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<int> values = valuesStrings.Select((int.Parse)).ToList();

            int numberOfOperations = values.Count - 1;

            List<List<Operators>> operationPermutation = GetCombinations(numberOfOperations);


            foreach (var per in operationPermutation)
            {
                long value = values[0];
                var remaining = values.Slice(1, values.Count - 1);

                for (int i = 0; i < remaining.Count; ++i)
                {
                    var op = per[i];
                    if (op == Operators.Add)
                    {
                        value += remaining[i];
                    }
                    else
                    {
                        value *= remaining[i];
                    }
                }

                if (value == expectedResult)
                {
                    sum += value;
                    break;
                }
            }
        }

        Console.WriteLine(sum);
    }

    private static List<List<Operators>> GetCombinations(int n)
    {
        List<List<Operators>> operationPermutation = [];

        GetCombinationsHelper(new(), n, operationPermutation);
        return operationPermutation;
    }

    private static void GetCombinationsHelper(List<Operators> current, int n, List<List<Operators>> result)
    {
        if (current.Count == n)
        {
            result.Add(current);
            return;
        }

        List<Operators> add =
        [
            ..current,
            Operators.Add
        ];
        List<Operators> multiple =
        [
            ..current,
            (Operators.Multiple)
        ];
        GetCombinationsHelper(add, n, result);
        GetCombinationsHelper(multiple, n, result);
    }

    private static void Part2(List<string> lines)
    {
        Console.WriteLine("Part 2");

        long sum = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split(":");
            var expectedResult = long.Parse(parts[0]);


            string[] valuesStrings = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<int> values = valuesStrings.Select((int.Parse)).ToList();

            int numberOfOperations = values.Count - 1;

            List<List<Operators>> operationPermutation = GetCombinationsConcatenate(numberOfOperations);


            foreach (var per in operationPermutation)
            {
                long value = values[0];
                var remaining = values.Slice(1, values.Count - 1);

                for (int i = 0; i < remaining.Count; ++i)
                {
                    var op = per[i];
                    if (op == Operators.Add)
                    {
                        value += remaining[i];
                    }
                    else if (op == Operators.Multiple)
                    {
                        value *= remaining[i];
                    }
                    else
                    {
                        value = long.Parse(value + remaining[i].ToString());
                    }
                }

                if (value == expectedResult)
                {
                    sum += value;
                    break;
                }
            }
        }

        Console.WriteLine(sum);
    }

    private static List<List<Operators>> GetCombinationsConcatenate(int n)
    {
        List<List<Operators>> operationPermutation = [];

        GetCombinationsConcatenationHelper(new(), n, operationPermutation);
        return operationPermutation;
    }

    private static void GetCombinationsConcatenationHelper(List<Operators> current, int n, List<List<Operators>> result)
    {
        if (current.Count == n)
        {
            result.Add(current);
            return;
        }

        List<Operators> add =
        [
            ..current,
            Operators.Add
        ];
        List<Operators> multiple =
        [
            ..current,
            (Operators.Multiple)
        ];
        List<Operators> concatenate =
        [
            ..current,
            (Operators.Concatenate)
        ];
        GetCombinationsConcatenationHelper(add, n, result);
        GetCombinationsConcatenationHelper(multiple, n, result);
        GetCombinationsConcatenationHelper(concatenate, n, result);
    }
}