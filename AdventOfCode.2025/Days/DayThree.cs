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
		var answer = instructions.Sum(instruction => FindMaxNumber(instruction.Numbers, 12));

		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static long FindMaxNumber(int[] numbers, int targetLength)
	{
		var result = new List<int>();
		var toSkip = numbers.Length - targetLength;
		var skipped = 0;

		foreach (var number in numbers)
		{
			while (result.Count > 0 && result[^1] < number && skipped < toSkip)
			{
				result.RemoveAt(result.Count - 1);
				skipped++;
			}

			result.Add(number);
		}

		result = result.Take(targetLength).ToList();

		return result.Aggregate<int, long>(0, (current, number) => current * 10 + number);
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
