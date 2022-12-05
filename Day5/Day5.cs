using System.Collections;
using System.Text;

namespace AdventOfCode;

public class Day5
{
    public static string SolvePart1(List<string> input)
    {
        var (stacks, commands) = ParseInput(input);
        
        foreach (var cmd in commands)
        {
            var (cnt, fromStack, toStack) = cmd;
            
            for (var i = 0; i < cnt; i++)
            {
                var item = stacks[fromStack].Pop();
                stacks[toStack].Push(item);
            }
        }

        return GetTops(stacks);
    }

    public static string SolvePart2(List<string> input)
    {
        var (stacks, commands) = ParseInput(input);
        
        foreach (var cmd in commands)
        {
            var (cnt, fromStack, toStack) = cmd;
            
            var tempStack = new Stack();
            for (var i = 0; i < cnt; i++)
            {
                var item = stacks[fromStack].Pop();
                tempStack.Push(item);
            }

            for (var i = 0; i < cnt; i++)
            {
                var item = tempStack.Pop();
                stacks[toStack].Push(item);
            }
        }

        return GetTops(stacks);
    }

    private static (Stack[] stacks, List<(int, int, int)> commands) ParseInput(List<string> input)
    {
        var stacks = new Stack[9]
        {
            new Stack("DMSZRFWN".ToCharArray()),
            new Stack("WPQGS".ToCharArray()),
            new Stack("WRVQFNJC".ToCharArray()),
            new Stack("FZPCGDL".ToCharArray()),
            new Stack("TPS".ToCharArray()),
            new Stack("HDFWRL".ToCharArray()),
            new Stack("ZNDC".ToCharArray()),
            new Stack("WNRFVSJQ".ToCharArray()),
            new Stack("RMSGZWV".ToCharArray())
        };

        var commands = new List<(int cnt, int fromStack, int toStack)>();
        foreach (var line in input)
        {
            var cmd = line.Split();
            var (cnt, fromStack, toStack) = (int.Parse(cmd[1]), int.Parse(cmd[3]) - 1, int.Parse(cmd[5]) - 1);
            commands.Add((cnt, fromStack, toStack));
        }

        return (stacks, commands);
    }

    private static string GetTops(Stack[] stacks)
    {
        var result = new StringBuilder();

        foreach (var stack in stacks)
            result.Append(stack.Peek());

        return result.ToString();
    }
}