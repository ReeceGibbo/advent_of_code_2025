using Spectre.Console;

namespace AdventOfCode2025;

public static class AnsiConsoleExtensions
{
    public static void WriteCentered(string markupText)
    {
        AnsiConsole.Write(Align.Center(new Markup(markupText), VerticalAlignment.Top));
    }
}