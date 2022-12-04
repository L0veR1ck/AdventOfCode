namespace AdventOfCode;

public class Day4
{
    public static string SolvePart1(List<string> input)
    {
        var data = ParseInput(input);

        var answer = 0;
        foreach (var elvesPair in data)
        {
            var (firstRange, secondRange) = elvesPair;
            if (firstRange.Contains(secondRange) || secondRange.Contains(firstRange))
                answer += 1;
        }

        return answer.ToString();
    }

    public static string SolvePart2(List<string> input)
    {
        var data = ParseInput(input);

        var answer = 0;
        foreach (var elvesPair in data)
        {
            var (firstRange, secondRange) = elvesPair;
            if (firstRange.OverlapsWith(secondRange) || secondRange.OverlapsWith(firstRange))
                answer += 1;
        }

        return answer.ToString();
    }

    private static List<(Range, Range)> ParseInput(List<string> input)
    {
        var result = new List<(Range, Range)>();
        foreach (var line in input)
        {
            var elves = line.Split(',');
            result.Add((GetRange(elves[0]), GetRange(elves[1])));
        }

        return result;
    }

    private static Range GetRange(string elfRange)
    {
        var elfNums = elfRange.Split('-');

        var elfLeft = int.Parse(elfNums[0]);
        var elfRight = int.Parse(elfNums[1]);
        return new Range(elfLeft, elfRight);
    }
}

public class Range
{
    public int Begin;
    public int End;

    public Range(int begin, int end)
    {
        Begin = begin;
        End = end;
    }

    public bool Contains(Range otherRange)
    {
        return otherRange.Begin >= this.Begin && otherRange.End <= this.End;
    }

    public bool OverlapsWith(Range otherRange)
    {
        return (this.Begin <= otherRange.Begin && otherRange.Begin <= this.End)
            || (this.Begin <= otherRange.End && otherRange.End <= this.End);
    }
}