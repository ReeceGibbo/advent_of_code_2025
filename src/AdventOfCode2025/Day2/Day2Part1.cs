namespace AdventOfCode2025.Day2;

public class Day2Part1
{
    private long _finalValue = 0;
    
    public List<long> GetInvalidIds(string input)
    {
        var splitInput = input.Split('-');
        var numberOne = long.Parse(splitInput[0]);
        var numberTwo = long.Parse(splitInput[1]);
        var invalidIds = new List<long>();

        var modifier = numberOne;
        
        while (modifier <= numberTwo)
        {
            var stringVersion = modifier.ToString();
            
            var isEven = stringVersion.Length % 2 == 0;
            if (!isEven)
            {
                modifier++;
                continue;
            }

            var half = stringVersion.Length / 2;
            var firstPart = stringVersion[0..half];
            var secondPart = stringVersion[half..stringVersion.Length];

            if (firstPart == secondPart)
            {
                // Found invalid ID
                invalidIds.Add(modifier);
            }

            modifier++;
        }

        return invalidIds;
    }

    public long GetFinalComputedValue()
    {
        return _finalValue;
    }
    
    public void Run(string[] input)
    {
        foreach (var line in input)
        {
            var invalidIds =  GetInvalidIds(line);

            foreach (var invalidId in invalidIds)
            {
                _finalValue += invalidId;
            }
        }
    }
}