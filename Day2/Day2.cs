namespace AdventOfCode;

public class Day2
{
    public static string SolvePart1(List<string> input)
    {
        var data = ParseInputPart1(input);
        var answer = 0;
        foreach (var line in data)
        {
            var enemyMove = line.Item1;
            var myMove = line.Item2;
            answer += GetResult(enemyMove, myMove);
        }

        return answer.ToString();
    }

    public static string SolvePart2(List<string> input)
    {
        var data = ParseInputPart2(input);
        var answer = 0;
        foreach (var line in data)
        {
            var enemyMove = line.Item1;
            var result = line.Item2;
            var myMove = GetMyMove(enemyMove, result);
            answer += GetResult(enemyMove, myMove);
        }

        return answer.ToString();
    }

    private static List<(string, string)> ParseInputPart1(List<string> input)
    {
        var translation = new Dictionary<string, string>()
        {
            { "A", "Rock" },
            { "B", "Paper" },
            { "C", "Scissors" },
            { "X", "Rock" },
            { "Y", "Paper" },
            { "Z", "Scissors" }
        };

        return TranslateInput(input, translation);
    }

    private static List<(string, string)> ParseInputPart2(List<string> input)
    {
        var translation = new Dictionary<string, string>()
        {
            { "A", "Rock" },
            { "B", "Paper" },
            { "C", "Scissors" },
            { "X", "Lose" },
            { "Y", "Draw" },
            { "Z", "Win" }
        };

        return TranslateInput(input, translation);
    }

    private static List<(string, string)> TranslateInput(List<string> input, Dictionary<string, string> translation)
    {
        var result = new List<(string, string)>();

        foreach (var line in input)
        {
            var moves = line.Split();
            result.Add((translation[moves[0]], translation[moves[1]]));
        }

        return result;
    }

    private static int GetResult(string enemyMove, string myMove)
    {
        var result = 0;

        switch (myMove)
        {
            case "Rock":
            {
                result += 1;

                switch (enemyMove)
                {
                    case "Rock":
                        result += 3;
                        break;
                    case "Paper":
                        result += 0;
                        break;
                    case "Scissors":
                        result += 6;
                        break;
                }

                break;
            }
            case "Paper":
            {
                result += 2;

                switch (enemyMove)
                {
                    case "Rock":
                        result += 6;
                        break;
                    case "Paper":
                        result += 3;
                        break;
                    case "Scissors":
                        result += 0;
                        break;
                }

                break;
            }
            case "Scissors":
            {
                result += 3;

                switch (enemyMove)
                {
                    case "Rock":
                        result += 0;
                        break;
                    case "Paper":
                        result += 6;
                        break;
                    case "Scissors":
                        result += 3;
                        break;
                }

                break;
            }
        }

        return result;
    }

    private static string GetMyMove(string enemyMove, string result)
    {
        switch (result)
        {
            case "Lose":
            {
                switch (enemyMove)
                {
                    case "Rock":
                        return "Scissors";
                    case "Paper":
                        return "Rock";
                    case "Scissors":
                        return "Paper";
                }

                break;
            }
            case "Draw":
            {
                return enemyMove;
            }
            case "Win":
            {
                switch (enemyMove)
                {
                    case "Rock":
                        return "Paper";
                    case "Paper":
                        return "Scissors";
                    case "Scissors":
                        return "Rock";
                }

                break;
            }
        }

        throw new Exception("Unknown input in Day2Task2");
    }
}