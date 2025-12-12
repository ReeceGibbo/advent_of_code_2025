using AdventOfCode2025.Rendering;

namespace AdventOfCode2025.Day6;

public class Day6Part2 : IDayPuzzle
{
    public Day6Part2(PuzzleInput input)
    {
        var datasets = input.Text
            .Trim()
            .Split("\n");

        if (datasets.Length < 1) throw new InvalidDataException();

        var operators = datasets[^1].Replace(" ", string.Empty);
        datasets = datasets[..^1];
        
        // Build numbers dataset
        var numbers = GetDatasetNumbers(datasets, operators.Length);
        
        // Calculate
        var totalValue = 0L;
        
        for (var o = 0; o < operators.Length; o++)
        {
            var o1 = o;

            var grabbedNumbers = new List<string>();
            for (var d = 0; d < datasets.Length; d++)
            {
                grabbedNumbers.Add(numbers[d, o1]);
            }
            
            if (grabbedNumbers.Count == 0)
                continue;

            var newNumbers = new List<long>();
            
            var biggestNumber = grabbedNumbers.MaxBy(n => n.Length);
            
            for (var i = biggestNumber.Length; i >= 0; i--)
            {
                var buildNumber = "";
                
                for (var n = 0; n < grabbedNumbers.Count; n++)
                {
                    var number = grabbedNumbers[n];
                    if (i >= number.Length)
                        continue;

                    if (char.IsNumber(number[i]))
                        buildNumber += number[i];
                }
                
                if (long.TryParse(buildNumber, out var result))
                    newNumbers.Add(result);
            }
            
            totalValue += operators[o] switch
            {
                '+' => newNumbers.Sum(),
                '*' => newNumbers.Aggregate((n1, n2) => n1 * n2),
                _ => throw new InvalidDataException()
            };
        }
    }

    private string[,] GetDatasetNumbers(string[] datasets, int operatorsLength)
    {
        // TEST
        var scanning = true;
        var index = 0;

        // Operators length is how many numbers there is
        var numbers = new string[datasets.Length, operatorsLength];
        
        // Create buffers
        var buffer = new List<char>[datasets.Length];
        for (var d = 0; d < datasets.Length; d++)
        {
            buffer[d] = new List<char>();
        }

        var num = 0;
        
        while (scanning)
        {
            var hasData = false;
            for (var d = 0; d < datasets.Length; d++)
            {
                if (index >= datasets[d].Length)
                    continue;

                hasData = true;
                var letter = datasets[d][index];
                buffer[d].Add(letter);
            }

            if (!hasData)
            {
                scanning = false;
                continue;
            }
            
            var data = datasets.Select(d => d[index]);
            // build numbers from the data :)
            if (data.All(char.IsWhiteSpace))
            {
                for (var b = 0; b < datasets.Length; b++)
                {
                    numbers[b, num] = new string(buffer[b].ToArray());
                    buffer[b].Clear();
                }
                // This means that it'll be a new number on the "next" index.
                num++;
            }
            
            index++;
        }
        
        // Final one
        for (var b = 0; b < datasets.Length; b++)
        {
            numbers[b, num] = new string(buffer[b].ToArray());
            buffer[b].Clear();
        }
        num++;

        return numbers;
    }
    
    public string GetAnswer()
    {
        return "42";
    }

    private class Range
    {
        public long Start { get; set; }
        public long End { get; set; }

        public Range(long start, long end)
        {
            Start = start;
            End = end;
        }
    }
}