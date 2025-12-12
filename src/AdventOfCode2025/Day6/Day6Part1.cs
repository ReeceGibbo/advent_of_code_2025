using AdventOfCode2025.Rendering;

namespace AdventOfCode2025.Day6;

public class Day6Part1 : IDayPuzzle
{
    public Day6Part1(PuzzleInput input)
    {
        var datasets = input.Text
            .Trim()
            .Split("\n");

        if (datasets.Length < 1) throw new InvalidDataException();

        var operators = datasets[^1].Replace(" ", string.Empty);
        datasets = datasets[..^1];
        
        // Build numbers dataset
        var numbers = new Dictionary<int, List<long>>();
        
        for (var d = 0; d < datasets.Length; d++)
        {
            numbers.TryAdd(d, GetNumbers(datasets[d]));
        }
        
        // Calculate
        var totalValue = 0L;
        
        for (var o = 0; o < operators.Length; o++)
        {
            var o1 = o;
            var grabbedNumbers = numbers
                .Select(n => n.Value[o1])
                .ToArray();

            if (grabbedNumbers.Length == 0)
                continue;

            totalValue += operators[o] switch
            {
                '+' => grabbedNumbers.Sum(),
                '*' => grabbedNumbers.Aggregate((n1, n2) => n1 * n2),
                _ => throw new InvalidDataException()
            };
        }
    }

    private List<long> GetNumbers(string data)
    {
        var numbers = new List<long>();

        var currentNumber = "";
        
        var enumerator = data.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            if (long.TryParse(current.ToString(), out var n))
            {
                currentNumber += current;
            }
            else if (!string.IsNullOrWhiteSpace(currentNumber))
            {
                var totalNumber = long.Parse(currentNumber);
                numbers.Add(totalNumber);
                currentNumber = "";
            }
        }
        
        if (!string.IsNullOrWhiteSpace(currentNumber))
        {
            var totalNumber = long.Parse(currentNumber);
            numbers.Add(totalNumber);
            currentNumber = "";
        }

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