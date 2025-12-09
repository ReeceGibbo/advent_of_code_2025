using AdventOfCode2025.Rendering;
using Spectre.Console;

namespace AdventOfCode2025.Screens;

public class ScreenPuzzleSolution : IScreen, IDynamicScreen
{
    public string Title { get; }

    private readonly PuzzleInput _input;
    private readonly IDayPuzzle _puzzle;

    private bool _hasRun;
    private string? _answer;
    private TimeSpan _elapsed;

    public ScreenPuzzleSolution(int day, int part, PuzzleInput input, IDayPuzzle puzzle)
    {
        Title = $"Day {day} - Part {part}";
        _input = input;
        _puzzle = puzzle;
    }

    public void Render()
    {
        if (!_hasRun)
            RunSolverOnce();

        var rows = new Rows(
            new Markup(
                $"[grey]Time: [yellow]{_elapsed.TotalMilliseconds:F2} ms[/][/]"),
            new Markup($"[green]Answer:[/] [bold yellow]{Markup.Escape(_answer ?? "<null>")}[/]")
        );

        AnsiConsole.Write(Align.Center(rows, VerticalAlignment.Top));
    }

    public bool Update(TimeSpan deltaTime)
    {
        return false;
    }

    public ScreenCommand HandleInput(ConsoleKeyInfo key)
    {
        return key.Key switch
        {
            ConsoleKey.B => ScreenCommand.Pop(),
            ConsoleKey.Q => ScreenCommand.ExitApp(),
            _ => ScreenCommand.None()
        };
    }

    private void RunSolverOnce()
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        _answer = _puzzle.GetAnswer();
        sw.Stop();
        _elapsed = sw.Elapsed;
        _hasRun = true;
    }
}