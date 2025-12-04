namespace AdventOfCode2025.Day3;

public class Day3Part2
{

    private string MaxSubsequenceNumber(string digits, int keep)
    {
        var n = digits.Length;
        var removals = n - keep;

        var stack = new char[n];
        var top = 0;

        foreach (var d in digits)
        {
            while (removals > 0 && top > 0 && stack[top - 1] < d)
            {
                top--;
                removals--;
            }

            stack[top++] = d;
        }

        top -= removals;

        if (top > keep)
            top = keep;
        
        return new string(stack, 0, top);
    }
    
    public long GetValue(string query)
    {
        return long.Parse(MaxSubsequenceNumber(query, 12));
    }
    
    public long Run(string[] input)
    {
        long finalValue = 0;

        foreach (var line in input)
        {
            finalValue += GetValue(line);
        }

        return finalValue;
    }
}