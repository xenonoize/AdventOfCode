using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayThree
{
	public static void Execute()
	{
		var instructions = ProcessInput(DayThreeInput.ExamplePuzzleInput);

		Console.WriteLine($"--- {nameof(DayThree)} ---");
		Part1(instructions);
		Part2(instructions);
		Console.WriteLine("--------------");
	}

	private static void Part1(Instruction[] instructions)
	{
		long answer = 0;

		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static void Part2(Instruction[] instructions)
	{
		long answer = 0;

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
		return [];
	}

	private record Instruction();
}
