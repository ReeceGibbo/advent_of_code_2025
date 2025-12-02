namespace AdventOfCode2025.Day2;

public class Day2Part2
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
            var digits = stringVersion.ToCharArray();
            var seenDigits = new HashSet<char>();
            var repeatedPhrases = new HashSet<string>();

            for (var x = 0; x < digits.Length; x++)
            {
                // Add the "current number" to the potential repeats
                if (seenDigits.Contains(digits[x]))
                {
                    var currentNumber = new string(digits[0..x]);
                    repeatedPhrases.Add(currentNumber);
                }
                
                seenDigits.Add(digits[x]);
            }

            foreach (var phrase in repeatedPhrases)
            {
                var repeatedPhrase = true;
                
                for (var x = phrase.Length; x < stringVersion.Length; x += phrase.Length)
                {
                    if (repeatedPhrase == false) continue;
                    var range = x + phrase.Length;
                    if (range > stringVersion.Length)
                    {
                        repeatedPhrase = false;
                        continue;
                    }

                    var currentNumber = stringVersion[x..range];
                    if (currentNumber != phrase) repeatedPhrase = false;
                }

                if (repeatedPhrase)
                {
                    if (!invalidIds.Contains(modifier))
                        invalidIds.Add(modifier);
                }
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