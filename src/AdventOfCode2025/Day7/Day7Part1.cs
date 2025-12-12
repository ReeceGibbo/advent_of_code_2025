using AdventOfCode2025.Rendering;

namespace AdventOfCode2025.Day6;

public class Day7Part1 : IDayPuzzle
{
    enum TileType
    {
        Empty = 0,
        Source = 1,
        Splitter = 2,
        Beam = 3
    }

    private readonly TileType[,] _tiles;
    private int amountOfSplits = 0;

    public Day7Part1(PuzzleInput input)
    {
        var datasets = input.Text
            .Trim()
            .Split("\n");

        // Setup data
        var width = datasets[0].Length;
        var height = datasets.Length;

        _tiles = new TileType[width, height];

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
        string building = "";
        
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var current = GetTileAtPosition(x, y);

                if (current == TileType.Source)
                {
                    ChangeTileAtPosition(x, y + 1, TileType.Beam);
                }
                else if (current == TileType.Splitter)
                {
                    var above = GetTileAtPosition(x, y - 1);
                    if (above == TileType.Beam || above == TileType.Source)
                    {
                        CreateBeamAtPosition(x + 1, y);
                        CreateBeamAtPosition(x - 1, y);
                        amountOfSplits++;
                    }
                }
                
                switch (current)
                {
                    case TileType.Beam:
                        building += ('|');
                        break;
                    case TileType.Source:
                        building += ('S');
                        break;
                    case TileType.Splitter:
                        building += ('^');
                        break;
                    case TileType.Empty:
                        building += ('.');
                        break;
                    default:
                        building += ("UNKNOWN");
                        break;
                }
            }

            building += "\n";
        }
        
        // Print map
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var current = GetTileAtPosition(x, y);
                switch (current)
                {
                    case TileType.Beam:
                        Console.Write('|');
                        break;
                    case TileType.Source:
                        Console.Write('S');
                        break;
                    case TileType.Splitter:
                        Console.Write('^');
                        break;
                    case TileType.Empty:
                        Console.Write('.');
                        break;
                    default:
                        Console.Write("UNKNOWN");
                        break;
                }
            }

            Console.WriteLine();
        }
    }

    private TileType GetTileAtPosition(int x, int y)
    {
        if (x < 0 || x >= _tiles.GetLength(0) || y < 0 || y >= _tiles.GetLength(1))
            return TileType.Empty;
        return _tiles[x, y];
    }

    private void ChangeTileAtPosition(int x, int y, TileType newType)
    {
        if (x < 0 || x >= _tiles.GetLength(0) || y < 0 || y >= _tiles.GetLength(1))
            return;
        
        _tiles[x, y] = newType;
    }

    private void CreateBeamAtPosition(int xPos, int yPos)
    {
        if (xPos < 0 || xPos >= _tiles.GetLength(0) || yPos < 0 || yPos >= _tiles.GetLength(1))
            return;

        for (var y = yPos; y < _tiles.GetLength(1); y++)
        {
            var current = GetTileAtPosition(xPos, y);
            if (current == TileType.Empty)
            {
                ChangeTileAtPosition(xPos, y, TileType.Beam);
            }
            else
            {
                return;
            }
        }
    }

    public string GetAnswer()
    {
        return "42";
    }
}