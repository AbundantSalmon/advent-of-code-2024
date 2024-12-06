namespace Day06;

internal static class Day06
{
	public static void Main(string[] args)
	{
		const string inputFile = "input.txt";

		Console.WriteLine("Day06!");

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

	enum Space
	{
		Blank,
		Obstruction
	}
	enum Facing
	{
		Up,
		Down,
		Left,
		Right,
	}

	private static Tuple<int, int> GetVector(Facing facing)
	{
		switch (facing)
		{
			case Facing.Up:
				return new Tuple<int, int>(0, -1);
			case Facing.Down:
				return new Tuple<int, int>(0, 1);
			case Facing.Left:
				return new Tuple<int, int>(-1, 0);
			case Facing.Right:
				return new Tuple<int, int>(1, 0);
			default:
				throw new Exception("Unexpected facing");
		}
	}

	private static Facing GetNextDirection(Facing facing)
	{
		switch (facing)
		{
			case Facing.Up:
				return Facing.Right;
			case Facing.Down:
				return Facing.Left;
			case Facing.Left:
				return Facing.Up;
			case Facing.Right:
				return Facing.Down;
			default:
				throw new Exception("Unexpected facing");
		}
	}

	private static void Part1(List<string> lines)
	{
		Console.WriteLine("Part 1");

		int width = 0;
		int height = 0;

		Dictionary<int, Dictionary<int, Space>> map = new();

		int currentGuardX = -1;
		int currentGuardY = -1;
		Facing currentFacing = Facing.Up;

		int y = 0;
		foreach (string row in lines)
		{
			if (y > height)
			{
				height = y;
			}
			int x = 0;
			foreach (char space in row.ToCharArray())
			{
				if (x > width)
				{
					width = x;
				}

				if (!map.ContainsKey(x))
				{
					map[x] = new Dictionary<int, Space>();
				}

				if (space == '.')
				{
					map[x][y] = Space.Blank;

				}
				else if (space == '#')
				{
					map[x][y] = Space.Obstruction;
				}
				else if (space == '^')
				{
					currentGuardX = x;
					currentGuardY = y;
				}
				else
				{
					throw new Exception("unexpected space: " + space);
				}
				++x;
			}
			++y;
		}

		Console.WriteLine("Current guard location: " + currentGuardX + " " + currentGuardY);

		bool outside = false;

		HashSet<Tuple<int, int>> visitedLocations = [new Tuple<int, int>(currentGuardX, currentGuardY)];

		while (!outside)
		{

			var walkForwardDirectionVector = GetVector(currentFacing);

			int nextX = currentGuardX + walkForwardDirectionVector.Item1;
			int nextY = currentGuardY + walkForwardDirectionVector.Item2;
			while (map.ContainsKey(nextX) && map[nextX].ContainsKey(nextY) && map[nextX][nextY] == Space.Obstruction)
			{
				currentFacing = GetNextDirection(currentFacing);
				var nextDirectionVector = GetVector(currentFacing);
				nextX = currentGuardX + nextDirectionVector.Item1;
				nextY = currentGuardY + nextDirectionVector.Item2;

			}
			if (nextX < 0 || nextX > width)
			{
				outside = true;
				continue;
			}
			if (nextY < 0 || nextY > height)
			{
				outside = true;
				continue;
			}

			currentGuardX = nextX;
			currentGuardY = nextY;
			visitedLocations.Add(new Tuple<int, int>(nextX, nextY));
		}

		Console.WriteLine(visitedLocations.Count);

	}

	private static void Part2(List<string> lines)
	{
		Console.WriteLine("Part 2");
	}
}