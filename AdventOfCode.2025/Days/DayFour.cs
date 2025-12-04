using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayFour
{
	public static void Execute()
	{
		var instructions = ProcessInput(DayFourInput.PuzzleInput);
		int[] dx = [-1, -1, -1, 0, 0, 1, 1, 1];
		int[] dy = [-1, 0, 1, -1, 1, -1, 0, 1];
		Console.WriteLine($"--- {nameof(DayFour)} ---");
		Part1(instructions, dx, dy);
		Part2(instructions, dx, dy);
		Console.WriteLine("--------------");
	}
	private static void Part1(char[][] grid, int[] dx, int[] dy)
	{
		long answer = 0;

		var rows = grid.Length;
		var columns = grid[0].Length;

		for (var row = 0; row < rows; row++)
		{
			for (var column = 0; column < columns; column++)
			{
				if (grid[row][column] != '@')
				{
					continue;
				}

				var adjacent = CountAdjacent(grid, row, column, dx, dy);

				if (adjacent < 4)
				{
					answer++;
				}
			}

		}


		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static void Part2(char[][] grid, int[] dx, int[] dy)
	{

		var answer = 0L;
		var rows = grid.Length;
		var columns = grid[0].Length;

		var removed = true;

		while (removed)
		{
			removed = false;
			var toRemove = new List<(int, int)>();
			for (var row = 0; row < rows; row++)
			{
				for (var column = 0; column < columns; column++)
				{
					if (grid[row][column] != '@')
					{
						continue;
					}

					var adjacent = CountAdjacent(grid, row, column, dx, dy);

					if (adjacent < 4)
					{
						toRemove.Add((row, column));
					}
				}
			}

			foreach (var (r, c) in toRemove)
			{
				grid[r][c] = '.';
				answer++;
				removed = true;
			}
		}

		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static int CountAdjacent(char[][] grid, int row, int column, int[] dx, int[] dy)
	{
		var count = 0;
		var rows = grid.Length;
		var columns = grid[0].Length;
		for (var direction = 0; direction < 8; direction++)
		{
			var newRow = row + dx[direction];
			var newColumn = column + dy[direction];
			if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns && grid[newRow][newColumn] == '@')
			{
				count++;
			}
		}
		return count;
	}


	private static char[][] ProcessInput(string input)
	{
		return input
			.Split('\n')
			.Select(line => line.ToCharArray())
			.ToArray();
	}
}
