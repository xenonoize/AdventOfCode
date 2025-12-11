using AdventOfCode._2025.Inputs;
namespace AdventOfCode._2025.Days;

public class DayEleven
{
	public static void Execute()
	{
		var graph = ProcessInput(DayElevenInput.PuzzleInput);
		Console.WriteLine($"--- {nameof(DayEleven)} ---");
		Part1(graph);
		Part2(graph);
		Console.WriteLine("--------------");
	}

	private static void Part1(Graph graph)
	{
		var pathCount = CountPaths(graph, "you", "out");
		Console.WriteLine($"Part 1 answer: {pathCount}");
	}

	private static void Part2(Graph graph)
	{
		var answer = 0L;
		Console.WriteLine($"Part 2 answer: {answer}");
	}

	private static long CountPaths(Graph graph, string start, string end)
	{
		if (start == end)
		{
			return 1;
		}

		return !graph.Connections.TryGetValue(start, out var value)
			? 0
			: value.Aggregate(0L, (acc, neighbor) => acc + CountPaths(graph, neighbor, end));

	}

	private static Graph ProcessInput(string input)
	{
		var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var connections = new Dictionary<string, List<string>>();

		foreach (var line in lines)
		{
			var parts = line.Split(':', StringSplitOptions.TrimEntries);
			if (parts.Length != 2)
			{
				continue;
			}
			var device = parts[0].Trim();
			var outputs = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

			connections[device] = new List<string>(outputs);
		}

		return new Graph(connections);
	}

	private record Graph(Dictionary<string, List<string>> Connections);
}
