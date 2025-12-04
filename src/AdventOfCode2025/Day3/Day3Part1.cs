namespace AdventOfCode2025.Day3;

public class Day3Part1
{
    public long GetValue(string query)
    {
        var data = query.ToCharArray()
            .Select(c => long.Parse(c.ToString()))
            .ToArray();

        var sortedWithIndex = data
            .Select((v, i) => new { Value = v, Index = i })
            .OrderByDescending(x => x.Value)
            .ToArray();

        for (var i = 0; i < sortedWithIndex.Length; i++)
        {
            var firstBattery = sortedWithIndex[i];
            var highestValue = 0L;

            foreach (var item in sortedWithIndex)
            {
                if (item.Value >= highestValue && item.Index > firstBattery.Index)
                {
                    highestValue = item.Value;
                }
            }

            if (highestValue != 0)
            {
                var combined = long.Parse($"{firstBattery.Value}{highestValue}");
                return combined;
            }
        }
        throw new Exception();
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