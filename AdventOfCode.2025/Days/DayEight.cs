using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayEight
{
	public static void Execute()
	{
		var instruction = ProcessInput(DayEightInput.PuzzleInput);
		Console.WriteLine($"--- {nameof(DayEight)} ---");
		Part1(instruction);
		Part2(instruction);
		Console.WriteLine("--------------");
	}
	private static void Part1(Instruction instruction)
	{
		var answer = 0L;
		Console.WriteLine($"Part 1 answer: {answer}");
	}


	private static void Part2(Instruction instruction)
	{
		var answer = 0L;
		Console.WriteLine($"Part 2 answer: {answer}");
	}



	private static Instruction ProcessInput(string input)
	{
		var lines = input.Split('\n');

		return new Instruction();
	}

	private record Instruction();
}
