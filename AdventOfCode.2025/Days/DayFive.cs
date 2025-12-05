using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayFive
{
	public static void Execute()
	{
		var instruction = ProcessInput(DayFiveInput.PuzzleInput);
		Console.WriteLine($"--- {nameof(DayFive)} ---");
		Part1(instruction);
		Part2(instruction);
		Console.WriteLine("--------------");
	}
	private static void Part1(Instruction instruction)
	{
		long answer = instruction.Numbers.LongCount(number => instruction.Ranges.Any(x => number >= x.Start && number <= x.End));

		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static void Part2(Instruction instruction)
	{
		var orderedRanges = instruction.Ranges.OrderBy(r => r.Start).ToList();
		var mergedRanges = new List<Range>();

		foreach (var range in orderedRanges)
		{
			if (mergedRanges.Count == 0 || mergedRanges[^1].End < range.Start - 1)
			{
				mergedRanges.Add(range);
			}
			else
			{
				var last = mergedRanges[^1];
				mergedRanges[^1] = last with
				{
					End = Math.Max(last.End, range.End)
				};
			}
		}

		long answer = mergedRanges.Aggregate(0L, (acc, r) => acc + (r.End - r.Start + 1));
		Console.WriteLine($"Part 2 answer: {answer}");

	}

	private static Instruction ProcessInput(string input)
	{
		var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var ranges = new List<Range>();
		var numbers = new List<long>();

		foreach (var line in lines)
		{
			if (!line.Contains('-'))
			{
				numbers.Add(long.Parse(line));
			}
			else
			{
				var splittedLine = line.Split('-');
				ranges.Add(new Range(long.Parse(splittedLine[0]), long.Parse(splittedLine[1])));
			}
		}

		return new Instruction(ranges, numbers);
	}

	private record Instruction(List<Range> Ranges, List<long> Numbers);

	private record Range(long Start, long End);
}
