using AdventOfCode2025.Rendering;
using Spectre.Console;

namespace AdventOfCode2025.Screens;

public class ScreenNotImplemented : IScreen
{
    public string Title => $"Day {_day} Part {_part}";

    private readonly int _day;
    private readonly int _part;

    public ScreenNotImplemented(int day, int part)
    {
        _day = day;
        _part = part;
    }

    public void Render()
    {
        AnsiConsoleExtensions.WriteCentered($"[red]Day {_day} Part {_part} has not implemented yet.[/]");
        AnsiConsole.WriteLine();
        AnsiConsoleExtensions.WriteCentered("[grey]Press [b]B[/] to go back.[/]");
        AnsiConsole.WriteLine();
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
}