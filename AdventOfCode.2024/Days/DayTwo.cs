using AdventOfCode._2024.Inputs;
namespace AdventOfCode._2024.Days;

public class DayTwo
{
	public static void Execute()
	{
		Console.WriteLine("--- DayTwo ---");
		Part1();
		Part2();
		Console.WriteLine("--------------");
	}

	private static void Part1()
	{
		long answer = 0;
		// var answer = ProcessInput(Input.Input.DayTwoInput).Where(IsValidSequence).Count();
		// var answer = ProcessInput(Input.Input.DayTwoInput).LongCount(IsValidSequence);

		foreach (var sequence in ProcessInput(Input.DayTwoInput))
		{
			if (IsValidSequence(sequence))
			{
				answer++;
			}
		}


		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static bool IsValidSequence(List<long> sequence)
	{
		var hasDecrease = false;
		var hasIncrease = false;

		for (var i = 0; i < sequence.Count - 1; i++)
		{
			var current = sequence[i];
			var next = sequence[i + 1];

			if (current == next)
			{
				return false;
			}

			long difference;

			if (current > next)
			{
				difference = Math.Abs(current - next);
				hasDecrease = true;
			}
			else
			{
				difference = Math.Abs(next - current);
				hasIncrease = true;
			}

			if (difference is < 1 or > 3)
			{
				return false;
			}
		}

		return !(hasDecrease && hasIncrease);
	}


	private static void Part2()
	{
		long answer = 0;
		foreach (var sequence in ProcessInput(Input.DayTwoInput))
		{
			if (IsValidSequence(sequence) || IsValidUnsafeSequence(sequence))
			{
				answer++;
			}
		}

		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static bool IsValidUnsafeSequence(List<long> sequence)
	{
		for (var i = 0; i < sequence.Count; i++)
		{
			var sequenceWithoutCurrent = new List<long>(sequence);

			var next = i + 1;

			sequenceWithoutCurrent.RemoveAt(i);

			if (IsValidSequence(sequenceWithoutCurrent))
			{
				return true;
			}

			if (next >= sequence.Count)
			{
				continue;
			}

			var sequenceWithoutNext = new List<long>(sequence);
			sequenceWithoutNext.RemoveAt(next);
			if (IsValidSequence(sequenceWithoutNext))
			{
				return true;
			}
		}

		return false;
	}

	private static IEnumerable<List<long>> ProcessInput(string input)
	{
		return input.Split('\n').Select(line => line.Split(" ").Select(long.Parse).ToList());
	}
}
