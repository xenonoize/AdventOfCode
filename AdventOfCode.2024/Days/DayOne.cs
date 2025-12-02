using AdventOfCode._2024.Inputs;
namespace AdventOfCode._2024.Days;

internal class DayOne
{

	public static void Execute()
	{
		Console.WriteLine("--- DayOne ---");
		Part1();
		Part2();
		Console.WriteLine("--------------");
	}

	private static void Part1()
	{
		var (firstList, secondList) = ProcessInput(Input.DayOneInput);
		long answer = 0;
		var firstListOrdered = firstList.OrderBy(x => x).ToList();
		var secondListOrdered = secondList.OrderBy(x => x).ToList();
		for (var i = 0; i < firstList.Count; i++)
		{
			answer += Math.Abs(firstListOrdered[i] - secondListOrdered[i]);
		}

		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static void Part2()
	{
		var (firstList, secondList) = ProcessInput(Input.DayOneInput);
		long answer = 0;
		var firstListOrdered = firstList.OrderBy(x => x).ToList();
		var secondListOrdered = secondList.OrderBy(x => x).ToList();

		foreach (var number in firstListOrdered)
		{
			answer += number * secondListOrdered.Count(x => x == number);
		}

		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static (List<long> FirstList, List<long> SecondList) ProcessInput(string input)
	{
		List<long> firstList = [];
		List<long> secondList = [];
		foreach (var line in input.Split('\n'))
		{
			var splittedLine = line.Split("   ");

			if (splittedLine.Length != 2)
			{
				continue;
			}

			firstList.Add(long.Parse(splittedLine[0]));
			secondList.Add(long.Parse(splittedLine[1]));
		}

		return (firstList, secondList);
	}
}
