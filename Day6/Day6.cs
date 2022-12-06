namespace AdventOfCode;

public class Day6
{
    public static string SolvePart1(List<string> input)
    {
        return Solve(input, 4);
    }

    public static string SolvePart2(List<string> input)
    {
        return Solve(input, 14);
    }

    private static string ParseInput(List<string> input)
    {
        return input[0];
    }

    private static string Solve(List<string> input, int charactersCount)
    {
        var data = ParseInput(input);
        var queue = InitializeQueue(data, charactersCount);

        for (var i = charactersCount; i < data.Length; i++)
        {
            if (FoundMarker(queue, charactersCount)) return i.ToString();
            queue.Dequeue();
            queue.Enqueue(data[i]);
        }

        return "Not found";
    }

    private static Queue<char> InitializeQueue(string data, int charactersCount)
    {
        var queue = new Queue<char>();
        for (var i = 0; i < charactersCount; i++)
        {
            queue.Enqueue(data[i]);
        }

        return queue;
    }

    private static bool FoundMarker(Queue<char> queue, int charactersCount)
    {
        return new HashSet<char>(queue).Count == charactersCount;
    }
}