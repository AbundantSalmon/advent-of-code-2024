using System.Diagnostics.Tracing;

namespace Day02;

enum ReactorState
{
	Increasing,
	Neutral,
	Decreasing
}

internal static class Day02
{
	public static void Main(string[] args)
	{
		const string inputFile = "input.txt";

		Console.WriteLine("Day02!");

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

		int numberOfSafeReports = 0;


		foreach (string line in lines)
		{
			var levels = line.Split(" ").ToList();
			int previousValue = int.Parse(levels[0]);
			levels.RemoveAt(0);
			ReactorState reactorState = ReactorState.Neutral;

			bool safe = true;

			foreach (string level in levels)
			{
				int value = int.Parse(level);
				int absChange = int.Abs(value - previousValue);
				if (value > previousValue)
				{
					if (reactorState == ReactorState.Decreasing)
					{
						safe = false;
						break;
					}
					reactorState = ReactorState.Increasing;
				}
				else if (value < previousValue)
				{
					if (reactorState == ReactorState.Increasing)
					{
						safe = false;
						break;
					}
					reactorState = ReactorState.Decreasing;
				}
				if (absChange < 1 || absChange > 3)
				{
					safe = false;
					break;
				}
				previousValue = value;
			}
			if (safe)
			{
				numberOfSafeReports += 1;
			}
		}

		Console.WriteLine(numberOfSafeReports);
	}

	private static void Part2(List<string> lines)
	{
		Console.WriteLine("Part 2");

		int numberOfSafeReports = 0;

		foreach (string line in lines)
		{
			var levels = line.Split(" ").ToList();

			if (IsSafe([.. levels]))
			{
				numberOfSafeReports += 1;
				continue;
			}

			// check iterations
			for (int i = 0; i < levels.Count; i++)
			{
				List<string> dampenedLevels = new(levels);
				dampenedLevels.RemoveAt(i);
				if (IsSafe(dampenedLevels))
				{
					numberOfSafeReports += 1;
					break;
				}
			}
		}

		Console.WriteLine(numberOfSafeReports);
	}

	private static bool IsSafe(List<string> levels)
	{
		int previousValue = int.Parse(levels[0]);
		levels.RemoveAt(0);
		ReactorState reactorState = ReactorState.Neutral;

		bool safe = true;

		foreach (string level in levels)
		{
			int value = int.Parse(level);
			int absChange = int.Abs(value - previousValue);
			if (value > previousValue)
			{
				if (reactorState == ReactorState.Decreasing)
				{
					safe = false;
					break;
				}
				reactorState = ReactorState.Increasing;
			}
			else if (value < previousValue)
			{
				if (reactorState == ReactorState.Increasing)
				{
					safe = false;
					break;
				}
				reactorState = ReactorState.Decreasing;
			}
			if (absChange < 1 || absChange > 3)
			{
				safe = false;
				break;
			}
			previousValue = value;
		}
		return safe;

	}
}