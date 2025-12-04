using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayFour
{
	public static void Execute()
	{
		var instructions = ProcessInput(DayFourInput.PuzzleInput);

		Console.WriteLine($"--- {nameof(DayFour)} ---");
		Part1(instructions);
		Part2(instructions);
		Console.WriteLine("--------------");
	}

	private static void Part1(char[][] grid)
	{
		long answer = 0;

		var rows = grid.Length;
		var columns = grid[0].Length;
		int[] dx = [-1, -1, -1, 0, 0, 1, 1, 1];
		int[] dy = [-1, 0, 1, -1, 1, -1, 0, 1];
		for (var row = 0; row < rows; row++)
		{
			for (var column = 0; column < columns; column++)
			{
				if (grid[row][column] != '@')
				{
					continue;
				}

				var adjacent = 0;

				for (var direction = 0; direction < 8; direction++)
				{
					var newRow = row + dx[direction];
					var newColumn = column + dy[direction];
					if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns && grid[newRow][newColumn] == '@')
					{
						adjacent++;
					}
				}

				if (adjacent < 4)
				{
					answer++;
				}
			}

		}


		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static void Part2(char[][] grid)
	{
		var answer = 0L;
		var rows = grid.Length;
		var columns = grid[0].Length;
		int[] dx = [-1, -1, -1, 0, 0, 1, 1, 1];
		int[] dy = [-1, 0, 1, -1, 1, -1, 0, 1];
		for (var row = 0; row < rows; row++)
		{
			for (var column = 0; column < columns; column++)
			{
				if (grid[row][column] != '@')
				{
					continue;
				}

				var adjecent = 0;

				for (var direction = 0; direction < 8; direction++)
				{
					var newRow = row + dx[direction];
					var newColumn = column + dy[direction];
					if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns && grid[newRow][newColumn] == '@')
					{
						adjecent++;
					}
				}

				if (adjecent < 4)
				{
					answer++;
				}
			}

		}
		Console.WriteLine($"Part 2 answer: {answer}");
	}



	private static char[][] ProcessInput(string input)
	{
		return input
			.Split('\n')
			.Select(line => line.ToCharArray())
			.ToArray();
	}
}
