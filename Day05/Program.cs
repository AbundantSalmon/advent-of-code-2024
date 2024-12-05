namespace Day05;

record Rule
{
	public readonly int before;
	public readonly int after;

	public Rule(int before, int after)
	{
		this.before = before;
		this.after = after;
	}
}
internal static class Day05
{
	public static void Main(string[] args)
	{
		const string inputFile = "input.txt";

		Console.WriteLine("Day05!");

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
		Dictionary<int, List<Rule>> rules = new();

		int sum = 0;

		bool haveAllRules = false;
		foreach (string line in lines)
		{
			if (line == "")
			{
				haveAllRules = true;
				continue;
			}

			if (haveAllRules)
			{
				var pageNumberUpdatesStrings = line.Split(",");
				List<int> pageNumberUpdates = [];
				foreach (var value in pageNumberUpdatesStrings)
				{
					pageNumberUpdates.Add(int.Parse(value));
				}

				bool valid = true;
				for (int i = 0; i < pageNumberUpdates.Count; ++i)
				{
					int currentPage = pageNumberUpdates[i];
					var rulesThatApply = rules[currentPage];
					foreach (var rule in rulesThatApply)
					{
						if (currentPage == rule.after)
						{
							for (int j = i + 1; j < pageNumberUpdates.Count; ++j)
							{
								int obsValue = pageNumberUpdates[j];
								if (rule.before == obsValue)
								{
									valid = false;
									break;
								}
							}

						}
						if (!valid)
						{
							break;
						}
					}

					if (!valid)
					{
						break;
					}
				}
				if (!valid)
				{
					continue;
				}

				// find middle
				int middleIndex = pageNumberUpdates.Count / 2;
				int middleValue = pageNumberUpdates[middleIndex];
				sum += middleValue;

			}
			else
			{
				List<string> values = line.Split("|").ToList();
				var before = int.Parse(values[0]);
				var after = int.Parse(values[1]);
				Rule newRule = new(before, after);
				if (!rules.ContainsKey(before))
				{
					rules.Add(before, []);
				}
				rules[before].Add(newRule);
				if (!rules.ContainsKey(after))
				{
					rules.Add(after, []);
				}
				rules[after].Add(newRule);

			}

		}

		Console.WriteLine(sum);
	}

	private static void Part2(List<string> lines)
	{
		Console.WriteLine("Part 2");

	}
}