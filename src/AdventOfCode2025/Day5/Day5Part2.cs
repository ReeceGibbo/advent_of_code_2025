using AdventOfCode2025.Rendering;

namespace AdventOfCode2025.Day5;

public class Day5Part2 : IDayPuzzle
{
    private readonly string[] _rangesParsed;
    private readonly List<Range> _ranges;

    public Day5Part2(PuzzleInput input)
    {
        var datasets = input.Text
            .Split("\n\n");

        if (datasets.Length < 1) throw new InvalidDataException();

        _rangesParsed = datasets[0]
            .Split('\n')
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrEmpty(l))
            .ToArray();

        _ranges = [];
        foreach (var range in _rangesParsed)
        {
            var split = range.Split("-");
            var start = long.Parse(split[0]);
            var end = long.Parse(split[1]);
            _ranges.Add(new Range(start, end));
        }
    }

    public string GetAnswer()
    {
        var orderedRanges = _ranges
            .OrderBy(r => r.Start)
            .ThenBy(r => r.End)
            .ToList();

        var finalRanges = new List<Range>();
        var currentRange = orderedRanges.First();
        
        foreach (var r in orderedRanges.Skip(1))
        {
            if (r.Start <= currentRange.End)
            {
                // Extend range
                if (r.End > currentRange.End)
                    currentRange.End = r.End;
            }
            else
            {
                // range starts at a completely different point
                finalRanges.Add(currentRange);
                currentRange = new Range(r.Start, r.End);
            }
        }
        
        // Add final range
        finalRanges.Add(currentRange);

        var total = finalRanges.Sum(r => (r.End - r.Start + 1));
        
        return total.ToString();
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