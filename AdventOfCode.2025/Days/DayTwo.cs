using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayTwo
{
	public static void Execute()
	{
		var instructions = ProcessInput(DayTwoInput.PuzzleInput);

		Console.WriteLine($"--- {nameof(DayTwo)} ---");
		Part1(instructions);
		Part2(instructions);
		Console.WriteLine("--------------");
	}

	private static void Part1(Instruction[] instructions)
	{
		long answer = 0;

		foreach (var instruction in instructions)
		{
			for (var id = instruction.Start; id <= instruction.End; id++)
			{
				var stringifiedId = id.ToString();
				var middle = stringifiedId.Length / 2;

				if (stringifiedId[..middle] == stringifiedId[middle..])
				{
					answer += id;
				}
			}
		}

		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static void Part2(Instruction[] instructions)
	{
		long answer = 0;

		foreach (var instruction in instructions)
		{
			for (var id = instruction.Start; id <= instruction.End; id++)
			{
				if (FindPattern(id.ToString()) != null)
				{
					answer += id;
				}
			}
		}

		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static string? FindPattern(string text)
	{
		for (int n = 1; n <= text.Length / 2; n++)
		{
			if (text.Length % n != 0)
			{
				continue;
			}

			string pattern = text[..n];
			int repeatCount = text.Length / pattern.Length;
			string repeated = string.Concat(Enumerable.Repeat(pattern, repeatCount));

			if (repeated == text)
			{
				return pattern;
			}
		}

		return null;
	}

	private static Instruction[] ProcessInput(string input)
	{
		return input
			.Split(',')
			.Select(range =>
			{
				var parts = range.Split('-');
				return new Instruction(long.Parse(parts[0]), long.Parse(parts[1]));
			})
			.ToArray();
	}

	private record Instruction(long Start, long End);
}
