using Spectre.Console;

namespace AdventOfCode2025.Day1;

public class Day1Part1 : IDayPuzzle
{
    private readonly string[] _input;

    private int _rotation = 50;
    private int _pointedAtZero = 0;

    /*
     * EG: R97, R83, L65, R90
     */
    public Day1Part1(string input)
    {
        var splitText = input
            .Split('\n')
            .Select(l => l.Trim())
            .Where(l => !string.IsNullOrEmpty(l))
            .ToArray();

        _input = splitText;
    }

    private void CalculateAnswer()
    {
        ConsoleUi.RunTimedProgress(
            "Day 1 - Part 1",
            _input.Length,
            task =>
            {
                foreach (var line in _input)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var decider = line[..1];
                    var number = int.Parse(line[1..]);

                    switch (decider)
                    {
                        case "R":
                            Rotate(true, number);
                            break;
                        case "L":
                            Rotate(false, number);
                            break;
                        default:
                            throw new Exception($"Unknown decider '{decider}'");
                    }

                    task.Increment(1);
                }
            });
        
        AnsiConsole.MarkupLine("[grey]Calculations complete, to see answer press[/] [green]Enter[/].");
        Console.ReadLine();
    }

    private void Rotate(bool right, int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            if (right)
            {
                _rotation += 1;
            }
            else
            {
                _rotation -= 1;
            }

            if (_rotation == 100)
            {
                _rotation = 0;
            }

            if (_rotation == -1)
            {
                _rotation = 99;
            }
        }

        if (_rotation == 0)
            _pointedAtZero++;
    }

    public string GetAnswer()
    {
        CalculateAnswer();
        return _pointedAtZero.ToString();
    }
}