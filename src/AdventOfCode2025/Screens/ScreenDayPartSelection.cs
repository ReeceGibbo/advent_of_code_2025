using AdventOfCode2025.Rendering;
using Spectre.Console;

namespace AdventOfCode2025.Screens;

public class ScreenDayPartSelection : IScreen
{
    public string Title => $"Day {_day} - Select Part";

    private readonly int _day;
    private int _selectedPart = 1;

    public ScreenDayPartSelection(int day)
    {
        _day = day;
    }

    public void Render()
    {
        var table = new Table()
            .Border(TableBorder.None);

        table.AddColumn(new TableColumn("Part").Centered());

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
                return ScreenCommand.Push(CreateDayPartScreen(_day, _selectedPart));

            case ConsoleKey.B:
                return ScreenCommand.Pop();

            case ConsoleKey.Q:
                return ScreenCommand.ExitApp();

            default:
                return ScreenCommand.None();
        }
    }

    private IScreen CreateDayPartScreen(int day, int part)
    {
        return (day, part) switch
        {
            // (1, 1) => new ScreenDay1Part1(),
            // (1, 2) => new ScreenDay1Part2(),
            // (2, 1) => new ScreenDay2Part1(),
            // (2, 2) => new ScreenDay2Part2(),
            // ...etc for all days...
            _ => new ScreenNotImplemented(day, part),
        };
    }
}