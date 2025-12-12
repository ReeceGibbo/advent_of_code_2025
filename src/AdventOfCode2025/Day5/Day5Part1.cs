using AdventOfCode2025.Rendering;

namespace AdventOfCode2025.Day5;

public class Day5Part1 : IDayPuzzle
{
    private readonly string[] _rangesParsed;
    private readonly string[] _valuesParsed;
    private readonly List<Range> _ranges;
    private readonly List<long> _values;
    
    public Day5Part1(PuzzleInput input)
    {
        var datasets = input.Text
            .Split("\n\n");

        if (datasets.Length < 1) throw new InvalidDataException();

        _rangesParsed = datasets[0]
            .Split('\n')
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrEmpty(l))
            .ToArray();
        
        _valuesParsed = datasets[1]
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

        _values = [];
        foreach (var value in _valuesParsed)
        {
            var parsed = long.Parse(value);
            _values.Add(parsed);
        }
    }
    
    public string GetAnswer()
    {
        var spoiled = 0;
        var fresh = 0;
        
        foreach (var value in _values)
        {
            var hasRange = false;
            foreach (var range in _ranges.Where(range => value >= range.Start && value <= range.End))
            {
                hasRange = true;
            }

            if (hasRange)
            {
                fresh++;
            }
            else
            {
                spoiled++;
            }
        }
        
        return fresh.ToString();
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