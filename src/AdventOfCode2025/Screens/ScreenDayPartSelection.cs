using AdventOfCode2025.Day1;
using AdventOfCode2025.Rendering;
using Spectre.Console;

namespace AdventOfCode2025.Screens;

public class ScreenDayPartSelection : IScreen
{
    public string Title => $"Day {_day} - Select Part";

    private readonly int _day;
    private readonly PuzzleInput _input;
    private int _selectedPart = 1;

    public ScreenDayPartSelection(int day, PuzzleInput input)
    {
        _day = day;
        _input = input;
    }

    public void Render()
    {
        var rows = new Rows(
            new Markup(
                $"[grey]Source:[/] [white]{Markup.Escape(_input.SourcePath ?? "<direct>")}[/]"),
            new Markup(
                $"[grey]Lines: [yellow]{_input.LineCount}[/], chars: [yellow]{_input.CharCount}[/][/]")
        );
        AnsiConsole.Write(Align.Center(rows, VerticalAlignment.Top));
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();

        var table = new Table()
            .Border(TableBorder.None);

        table.AddColumn(new TableColumn("Select Part to Run:").Centered());

        var part1Label = _selectedPart == 1
            ? "[black on yellow]  Part 1  [/]"
            : "[white]  Part 1  [/]";

        var part2Label = _selectedPart == 2
            ? "[black on yellow]  Part 2  [/]"
            : "[white]  Part 2  [/]";

        table.AddRow(new Markup(part1Label));
        table.AddRow(new Markup(part2Label));

        AnsiConsole.Write(Align.Center(table, VerticalAlignment.Top));
        AnsiConsole.WriteLine();
    }

    public ScreenCommand HandleInput(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.LeftArrow:
                _selectedPart = 1;
                return ScreenCommand.None();

            case ConsoleKey.DownArrow:
            case ConsoleKey.RightArrow:
                _selectedPart = 2;
                return ScreenCommand.None();

            case ConsoleKey.Enter:
                return ScreenCommand.Push(CreateNextScreen());

            case ConsoleKey.B:
                return ScreenCommand.Pop();

            case ConsoleKey.Q:
                return ScreenCommand.ExitApp();

            default:
                return ScreenCommand.None();
        }
    }

    private IScreen CreateNextScreen()
    {
        var part = _selectedPart;

        IDayPuzzle? puzzle = (_day, part) switch
        {
            (1, 1) => new Day1Part1(_input),
            (1, 2) => new Day1Part2(_input),
            _ => null
        };

        if (puzzle is null)
            return new ScreenNotImplemented(_day, part);

        return (_day, part) switch
        {
            _ => new ScreenPuzzleSolution(_day, part, _input, puzzle),
        };
    }
}