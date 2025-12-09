using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayNine
{
	public static void Execute()
	{
		var instruction = ProcessInput(DayNineInput.PuzzleInput);
		Console.WriteLine($"--- {nameof(DayNine)} ---");
		Part1(instruction);
		Part2(instruction);
		Console.WriteLine("--------------");
	}

	private static void Part1(Instruction instruction)
	{
		var redTiles = instruction.RedTiles;
		long maxArea = 0;

		for (var i = 0; i < redTiles.Count; i++)
		{
			for (var j = i + 1; j < redTiles.Count; j++)
			{
				var (x1, y1) = redTiles[i];
				var (x2, y2) = redTiles[j];
				var area = (Math.Abs(x1 - x2) + 1) * (Math.Abs(y1 - y2) + 1);
				if (area > maxArea)
				{
					maxArea = area;
				}
			}
		}

		Console.WriteLine($"Part 1 answer: {maxArea}");
	}


	private static void Part2(Instruction instruction)
	{
		var answer = 0L;
		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static Instruction ProcessInput(string input)
	{
		var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var redTiles = new List<(long x, long y)>();
		foreach (var line in lines)
		{
			var parts = line.Split(',');
			if (parts.Length == 2 &&
			    long.TryParse(parts[0], out var x) &&
			    long.TryParse(parts[1], out var y))
			{
				redTiles.Add((x, y));
			}
		}
		return new Instruction(redTiles);
	}

	private record Instruction(List<(long x, long y)> RedTiles);
}
