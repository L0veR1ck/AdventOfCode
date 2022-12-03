namespace AdventOfCode;

public class Day3
{
    private const string Alphabet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string SolvePart1(List<string> input)
    {
        var data = ParseInputPart1(input);

        var answer = 0;
        foreach (var pair in data)
        {
            var firstRucksack = new HashSet<char>(pair.Item1);
            var secondRucksack = new HashSet<char>(pair.Item2);

            var intersection = firstRucksack.Intersect(secondRucksack);

            foreach (var elem in intersection)
                answer += Alphabet.IndexOf(elem);
        }

        return answer.ToString();
    }

    public static string SolvePart2(List<string> input)
    {
        var data = ParseInputPart2(input);

        var answer = 0;
        foreach (var triple in data)
        {
            var firstRucksack = new HashSet<char>(triple.Item1);
            var secondRucksack = new HashSet<char>(triple.Item2);
            var thirdRucksack = new HashSet<char>(triple.Item3);

            var intersection = firstRucksack.Intersect(secondRucksack).Intersect(thirdRucksack);

            foreach (var elem in intersection)
                answer += Alphabet.IndexOf(elem);
        }

        return answer.ToString();
    }

    private static List<(string, string, string)> ParseInputPart2(List<string> input)
    {
        var result = new List<(string, string, string)>();
        for (var i = 0; i < input.Count; i += 3)
        {
            result.Add((input[i], input[i + 1], input[i + 2]));
        }

        return result;
    }

    private static List<(string, string)> ParseInputPart1(List<string> input)
    {
        var result = new List<(string, string)>();

        foreach (var line in input)
        {
            var n = line.Length;
            var string1 = line.Substring(0, n / 2);
            var string2 = line.Substring(n / 2, n / 2);
            result.Add((string1, string2));
        }

        return result;
    }
}