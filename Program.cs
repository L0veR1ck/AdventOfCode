namespace AdventOfCode;

static class Program
{
    private const string Path = "/Users/l0ver1ck/Desktop/repos/AdventOfCode";
    private const int Day = 2;

    static void Main()
    {
        for (var i = 1; i <= Day; i++)
        {
            var input = ReadInput($"{Path}/Day{i}/day{i}.txt");

            var obj = Type.GetType($"AdventOfCode.Day{i}");
            
            var method1 = obj?.GetMethod("SolvePart1");
            var method2 = obj?.GetMethod("SolvePart2");

            var answerPart1 = method1?.Invoke(obj, new object[] { input });
            var answerPart2 = method2?.Invoke(obj, new object[] { input });
            
            Console.WriteLine($"Day {i} | Part 1: {answerPart1}");
            Console.WriteLine($"Day {i} | Part 2: {answerPart2}");
            Console.WriteLine();
        }
    }

    private static List<string> ReadInput(string path)
    {
        var result = new List<string>();
        try
        {
            var sr = new StreamReader(path);
            while (sr.ReadLine() is { } line)
                result.Add(line);

            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }

        return result;
    }
}