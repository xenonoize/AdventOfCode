using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

internal class DaySix
{
	private const char Add = '+';
	private const char Multiply = '*';

	public static void Execute()
	{
		var instruction = ProcessInput(DaySixInput.PuzzleInput);
		Console.WriteLine($"--- {nameof(DaySix)} ---");
		Part1(instruction);
		Part2(instruction);
		Console.WriteLine("--------------");
	}
	private static void Part1(string[] lines)
	{
		var problems = FindProblemBoundaries(lines);
		var answer = problems.Aggregate(0L, (acc, p) => acc + SolveProblem(lines, p.start, p.end));
		Console.WriteLine($"Part 1 answer: {answer}");
	}

	private static List<(int start, int end)> FindProblemBoundaries(string[] lines)
	{
		var columnCount = lines.Max(l => l.Length);
		var problems = new List<(int start, int end)>();
		var problemStart = -1;

		for (var column = 0; column <= columnCount; column++)
		{
			var allSpaces = column == columnCount || IsColumnAllSpaces(lines, column);

			if (allSpaces && problemStart >= 0)
			{
				problems.Add((problemStart, column - 1));
				problemStart = -1;
			}
			else if (!allSpaces && problemStart < 0)
			{
				problemStart = column;
			}
		}

		return problems;
	}

	private static bool IsColumnAllSpaces(string[] lines, int column)
	{
		return lines.All(line => column >= line.Length || line[column] == ' ');
	}

	private static long SolveProblem(string[] lines, int start, int end)
	{
		var numbers = ExtractNumbers(lines, start, end);
		var operation = ExtractOperator(lines, start, end);
		return numbers.Count == 0 ? 0 : ApplyOperation(numbers, operation);
	}

	private static List<long> ExtractNumbers(string[] lines, int start, int end)
	{
		var numbers = new List<long>();

		foreach (var line in lines)
		{
			var segment = ExtractSegment(line, start, end);
			if (segment != null && long.TryParse(segment, out var num))
			{
				numbers.Add(num);
			}
		}

		return numbers;
	}

	private static char ExtractOperator(string[] lines, int start, int end)
	{
		foreach (var line in lines)
		{
			var segment = ExtractSegment(line, start, end);
			if (segment is { Length: 1 } && (segment[0] == Multiply || segment[0] == Add))
			{
				return segment[0];
			}
		}

		return Add;
	}

	private static string? ExtractSegment(string line, int start, int end)
	{
		var minStart = Math.Min(start, line.Length);
		var minEnd = Math.Min(end + 1, line.Length);
		return minStart >= minEnd ? null : line.Substring(minStart, minEnd - minStart).Trim();
	}

	private static long ApplyOperation(List<long> numbers, char operation)
	{
		return operation == Add ? numbers.Sum() : numbers.Aggregate(1L, (a, b) => a * b);
	}

	private static void Part2(string[] lines)
	{
		var problems = FindProblemBoundaries(lines);
		var answer = problems.Aggregate(0L, (acc, p) => acc + SolveProblemReversed(lines, p.start, p.end));
		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static long SolveProblemReversed(string[] lines, int start, int end)
	{
		var numbers = new List<long>();
		var operation = Add;

		for (var column = end; column >= start; column--)
		{
			var columnChars = lines.Select(line => line[column]).ToList();

			if (columnChars.Any(c => c == Multiply))
			{
				operation = Multiply;
			}
			else if (columnChars.Any(c => c == Add))
			{
				operation = Add;
			}

			var digits = columnChars.Where(char.IsDigit).ToArray();
			if (digits.Length <= 0)
			{
				continue;
			}
			var numStr = new string(digits);
			if (long.TryParse(numStr, out var num))
			{
				numbers.Add(num);
			}
		}

		return numbers.Count == 0 ? 0 : ApplyOperation(numbers, operation);
	}

	private static string[] ProcessInput(string input)
	{
		var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
		var maxLength = lines.Max(l => l.Length);
		return lines.Select(l => l.PadRight(maxLength)).ToArray();
	}
}
