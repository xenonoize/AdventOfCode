using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DaySeven
{
	public static void Execute()
	{
		var instruction = ProcessInput(DaySevenInput.PuzzleInput);
		Console.WriteLine($"--- {nameof(DaySeven)} ---");
		Part1(instruction);
		Part2(instruction);
		Console.WriteLine("--------------");
	}
	private static void Part1(ManifoldState manifold)
	{
		var answer = SimulateBeams(manifold);
		Console.WriteLine($"Part 1 answer: {answer}");
	}


	private static void Part2(ManifoldState manifold)
	{
		var answer = CountTimelines(manifold);
		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static int SimulateBeams(ManifoldState manifold)
	{
		var activeColumns = new HashSet<int>
		{
			manifold.StartColumn
		};

		var splitCount = 0;

		for (var row = manifold.StartRow + 1; row < manifold.Grid.Length; row++)
		{
			var nextActiveColumns = new HashSet<int>();

			foreach (var column in activeColumns.Where(col => col >= 0 && col < manifold.Grid[row].Length))
			{
				if (manifold.Grid[row][column] == '^')
				{
					splitCount++;
					nextActiveColumns.Add(column - 1);
					nextActiveColumns.Add(column + 1);
				}
				else
				{
					nextActiveColumns.Add(column);
				}
			}
			activeColumns = nextActiveColumns;
			if (activeColumns.Count == 0) break;
		}

		return splitCount;
	}

	private static long CountTimelines(ManifoldState manifold)
	{
		var timelines = new Dictionary<int, long>
		{
			{
				manifold.StartColumn, 1L
			}
		};

		for (var row = manifold.StartRow + 1; row < manifold.Grid.Length; row++)
		{
			var nextTimelines = new Dictionary<int, long>();

			foreach (var (column, count) in timelines)
			{
				if (column < 0 || column >= manifold.Grid[row].Length)
				{
					continue;
				}

				if (manifold.Grid[row][column] == '^')
				{
					AddOrUpdate(column - 1, count, nextTimelines);
					AddOrUpdate(column + 1, count, nextTimelines);
				}
				else
				{
					AddOrUpdate(column, count, nextTimelines);
				}
			}

			timelines = nextTimelines;

			if (timelines.Count == 0)
			{
				break;
			}
		}

		return timelines.Values.Aggregate(0L, (accumulate, value) => accumulate + value);
	}

	private static void AddOrUpdate(int key, long value, Dictionary<int, long>? nextTimelines)
	{
		if (!nextTimelines?.TryAdd(key, value) ?? false)
		{
			nextTimelines[key] += value;
		}
	}

	private static ManifoldState ProcessInput(string input)
	{
		var lines = input.Split('\n');
		var maxLineLength = lines.Max(l => l.Length);
		var grid = lines.Select(l => l.PadRight(maxLineLength, '.')).ToArray();

		var startRow = Array.FindIndex(grid, row => row.Contains('S'));
		var startColumn = startRow != -1 ? grid[startRow].IndexOf('S') : -1;

		return new ManifoldState(startRow, startColumn, grid);
	}

	private record ManifoldState(int StartRow, int StartColumn, string[] Grid);
}
