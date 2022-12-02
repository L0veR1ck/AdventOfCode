namespace AdventOfCode;

public class Day1
{
    public static string SolvePart1(List<string> input)
    {
        var data = ParseInputDay1(input);
        return data.Max().ToString();
    }

    public static string SolvePart2(List<string> input)
    {
        var data = ParseInputDay1(input);
        data = data.OrderDescending().ToList();

        var answer = 0;
        for (var i = 0; i < 3; i++)
            answer += data[i];

        return answer.ToString();
    }

    private static List<int> ParseInputDay1(List<string> input)
    {
        var result = new List<int>();
        var currentCalories = 0;
        foreach (var line in input)
        {
            if (line == string.Empty)
            {
                result.Add(currentCalories);
                currentCalories = 0;
            }
            else
            {
                currentCalories += int.Parse(line);
            }
        }

        return result;
    }
}