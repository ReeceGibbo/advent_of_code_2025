using AdventOfCode2025.Rendering;

namespace AdventOfCode2025.Day6;

public class Day7Part2 : IDayPuzzle
{
    enum TileType
    {
        Empty = 0,
        Source = 1,
        Splitter = 2,
        Beam = 3
    }

    private readonly TileType[,] _tiles;
    private readonly long?[,] _memo;
    private long amountOfTimelines = 0;

    public Day7Part2(PuzzleInput input)
    {
        var datasets = input.Text
            .Trim()
            .Split("\n");
        
        // Setup data
        var width = datasets[0].Length;
        var height = datasets.Length;

        _tiles = new TileType[width, height];
        _memo = new long?[_tiles.GetLength(0), _tiles.GetLength(1) + 1];

        for (var y = 0; y < height; y++)
        {
            var line = datasets[y];
            for (var x = 0; x < width; x++)
            {
                var currentCharacter = line[x];
                if (currentCharacter == '.')
                {
                    _tiles[x, y] = TileType.Empty;
                }
                else if (currentCharacter == '^')
                {
                    _tiles[x, y] = TileType.Splitter;
                }
                else if (currentCharacter == 'S')
                {
                    _tiles[x, y] = TileType.Source;
                }
            }
        }

        // Process data
        ProcessData();
    }

    private long CountTimelinesFrom(int xPos, int yPos)
    {
        if (xPos < 0 || xPos >= _tiles.GetLength(0) || yPos < 0 || yPos >= _tiles.GetLength(1))
            return 1;

        var cached = _memo[xPos, yPos];
        if (cached.HasValue)
            return cached.Value;
        
        for (var y = yPos; y < _tiles.GetLength(1); y++)
        {
            var current = GetTileAtPosition(xPos, y);

            if (current == TileType.Splitter)
            {
                var leftTimelines = CountTimelinesFrom(xPos + 1, y + 1);
                var rightTimelines = CountTimelinesFrom(xPos - 1, y + 1);
                var total = leftTimelines + rightTimelines;
                _memo[xPos, yPos] = total;
                return total;
            }
        }

        _memo[xPos, yPos] = 1;
        return 1;
    }

    private void ProcessData()
    {
        for (var y = 0; y < _tiles.GetLength(1); y++)
        {
            for (var x = 0; x < _tiles.GetLength(0); x++)
            {
                var current = GetTileAtPosition(x, y);

                if (current == TileType.Source)
                {
                    amountOfTimelines = CountTimelinesFrom(x, y + 1);
                    return;
                }
            }
        }
    }

    private TileType GetTileAtPosition(int x, int y)
    {
        if (x < 0 || x >= _tiles.GetLength(0) || y < 0 || y >= _tiles.GetLength(1))
            return TileType.Empty;
        return _tiles[x, y];
    }

    public string GetAnswer()
    {
        return "42";
    }
}