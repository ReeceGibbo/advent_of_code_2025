using Spectre.Console;

namespace AdventOfCode2025.Rendering;

public sealed record PuzzleInput(
    string Text,
    int LineCount,
    int CharCount,
    string? SourcePath);

public static class PuzzleInputReader
{
    public static PuzzleInput RequestPuzzleInput(int day, int? part = null)
    {
        var partLabel = part.HasValue ? $" Part {part.Value}" : string.Empty;

        AnsiConsole.MarkupLine(
            $"[bold]Provide Puzzle Input for Day {day}{partLabel}:[/]\n" +
            "- drag & drop your input file into the console and press [green]Enter[/]\n" +
            "- or paste a full file path and press [green]Enter[/]\n");

        while (true)
        {
            AnsiConsole.Markup("[blue]> [/]");

            var line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                AnsiConsole.MarkupLine("[red]Empty input, try again.[/]");
                continue;
            }

            line = line.Trim();

            if ((line.StartsWith("\"") && line.EndsWith("\"")) ||
                (line.StartsWith("'") && line.EndsWith("'")))
            {
                line = line.Substring(1, line.Length - 2);
            }

            if (File.Exists(line))
            {
                var text = File.ReadAllText(line);

                var lineCount = text
                    .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                    .Length;

                AnsiConsole.MarkupLine(
                    $"[green]Loaded puzzle input from file:[/] [white]{Markup.Escape(line)}[/]");
                AnsiConsole.MarkupLine(
                    $"[grey]Lines: [yellow]{lineCount}[/], chars: [yellow]{text.Length}[/][/]");

                return new PuzzleInput(text, lineCount, text.Length, line);
            }

            AnsiConsole.MarkupLine(
                $"[red]File not found:[/] [white]{Markup.Escape(line)}[/]\n" +
                "[grey]Drag the file in again or paste a valid path.[/]");
        }
    }
}