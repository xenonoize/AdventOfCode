using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayThree
{
	public static void Execute()
	{
		var instructions = ProcessInput(DayThreeInput.PuzzleInput);

		Console.WriteLine($"--- {nameof(DayThree)} ---");
		Part1(instructions);
		Part2(instructions);
		Console.WriteLine("--------------");
	}

	private static void Part1(Instruction[] instructions)
	{
		long answer = 0;

		foreach (var instruction in instructions)
		{
			var largestValue = instruction.Numbers
				.SelectMany((first, i) => instruction.Numbers
					.Skip(i + 1)
					.Select(second => first * 10 + second))
				.Max();
			answer += largestValue;
		}
		Console.WriteLine($"Part 1 answer: {answer}");
	}




	private static void Part2(Instruction[] instructions)
	{
		long answer = 0;

		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static Instruction[] ProcessInput(string input)
	{
		return input
			.Split('\n')
			.Select(x => x.Select(c => (int)char.GetNumericValue(c)).ToArray())
			.Select(numbers => new Instruction(numbers))
			.ToArray();
	}

	private record Instruction(int[] Numbers);
}
