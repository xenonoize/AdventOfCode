using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DayOne
{
	public static void Execute()
	{
		var instructions = ProcessInput(DayOneInput.PuzzleInput);

		Console.WriteLine($"--- {nameof(DayOne)} ---");
		Part1(instructions);
		Part2(instructions);
		Console.WriteLine("--------------");
	}

	private static void Part1(Instruction[] instructions)
	{
		var dial = 50;
		var rotations = 0;
		foreach (var instruction in instructions)
		{
			if (instruction.Direction == 'L')
			{
				dial = (dial - instruction.Value + 100) % 100;
			}
			else if (instruction.Direction == 'R')
			{
				dial = (dial + instruction.Value) % 100;
			}

			if (dial == 0)
			{
				rotations++;
			}
		}

		Console.WriteLine($"Part 1 answer: {rotations}");
	}

	private static void Part2(Instruction[] instructions)
	{
		var dial = 50;
		var rotations = 0;
		foreach (var instruction in instructions)
		{
			var step = instruction.Direction == 'L' ? -1 : 1;
			for (var i = 0; i < instruction.Value; i++)
			{
				dial = (dial + step + 100) % 100;
				if (dial == 0)
				{
					rotations++;
				}
			}
		}
		Console.WriteLine($"Part 2 answer: {rotations}");
	}

	private static Instruction[] ProcessInput(string input)
	{
		return Regexes.InstructionRegex().Matches(input)
			.Select(m => new Instruction(m.Value[0], int.Parse(m.Value[1..])))
			.ToArray();
	}

	private record Instruction(char Direction, int Value);
}
