// See https://aka.ms/new-console-template for more information

using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;
using AdventOfCode2025.Day4;
using Spectre.Console;

namespace AdventOfCode2025;

public class Program
{
    public static void Main(string[] args)
    {
        App.Run();
        
        // AnsiConsole.MarkupLine("[bold aqua]----------------------------------------[/]");
        // AnsiConsole.MarkupLine("[bold aqua]Advent of Code Launcher[/]");
        // AnsiConsole.MarkupLine("Use arrows and [green]Enter[/] to choose a day/part.");
        // AnsiConsole.MarkupLine("[bold aqua]----------------------------------------[/]");
        //
        // AnsiConsole.WriteLine();
        //
        // var selection = PromptForDayAndPart();
        // if (selection is null)
        // {
        //     AnsiConsole.MarkupLine("[yellow]No selection made, exiting.[/]");
        //     return;
        // }
        //
        // var input = PromptForPuzzleInput(selection);
        //
        // AnsiConsole.Clear();
        // AnsiConsole.MarkupLine($"[bold]You selected:[/] [green]{selection}[/]");
        // AnsiConsole.MarkupLine(
        //     $"[grey]Loaded puzzle input with [yellow]{input.LineCount}[/] lines and [yellow]{input.CharCount}[/] characters.[/]");
        //
        // RunPuzzle(selection, input.Text);

        var baseDir = AppContext.BaseDirectory;
        // var path = Path.Combine(baseDir, "puzzle_inputs", "day1_input.txt");
        //
        // if (!File.Exists(path))
        // {
        //     Console.WriteLine($"File not found: {path}");
        //     return;
        // }
        //
        // var text = File.ReadAllText(path);
        //
        // var day1Test = new Day1();
        // var splitText = text.Trim().Split('\n');
        // day1Test.Run(splitText);
        // var day1Result = day1Test.GetPassword();
        // var day1ResultPart2 = day1Test.GetPassword_Part2();
        // Console.WriteLine($"Password: {day1Result}");
        // Console.WriteLine($"Password (Part 2): {day1ResultPart2}");

        // var path = Path.Combine(baseDir, "puzzle_inputs", "day2_input.txt");
        //
        // if (!File.Exists(path))
        // {
        //     Console.WriteLine($"File not found: {path}");
        //     return;
        // }
        //
        // var text = File.ReadAllText(path);
        // var splitText = text.Trim().Split(',');
        //
        // var day2Test = new Day2Part1();
        // day2Test.Run(splitText);
        //
        // Console.WriteLine($"Password: {day2Test.GetFinalComputedValue()}");
        //
        // var day2TestPart2 = new Day2Part2();
        // day2TestPart2.Run(splitText);
        //
        // Console.WriteLine($"Password: {day2TestPart2.GetFinalComputedValue()}");
        // Console.WriteLine($"Password (Part 2): {day1ResultPart2}");

        // var path = Path.Combine(baseDir, "puzzle_inputs", "day3_input.txt");
        //
        // if (!File.Exists(path))
        // {
        //     Console.WriteLine($"File not found: {path}");
        //     return;
        // }
        //
        // var text = File.ReadAllText(path);
        // var splitText = text.Trim().Split('\n');
        //
        // var day3Test = new Day3Part1();
        // var day3Result = day3Test.Run(splitText);
        //
        // var day3Test2 = new Day3Part2();
        // var day3Result2 = day3Test2.Run(splitText);
        //
        // Console.WriteLine($"Password: {day3Result}");
        // Console.WriteLine($"Password 2: {day3Result2}");

        // var path = Path.Combine(baseDir, "puzzle_inputs", "day4_input.txt");
        //
        // if (!File.Exists(path))
        // {
        //     Console.WriteLine($"File not found: {path}");
        //     return;
        // }
        //
        // var text = File.ReadAllText(path);
        // var splitText = text.Trim().Split('\n');
        //
        // var day4 = new Day4Part1();
        // var day4Result = day4.Run(splitText);
        //
        // var day4Part2 = new Day4Part2();
        // var day4Result2 = day4Part2.Run(splitText);
        //
        // Console.WriteLine($"Password: {day4Result}");
        // Console.WriteLine($"Password (Part 2): {day4Result2}");
    }

    record PuzzleSelection(int Day, int Part)
    {
        public override string ToString() => $"Day {Day:00} (Part {Part})";
    }

    record PuzzleInput(string Text, int LineCount, int CharCount, string? SourcePath);

    private static PuzzleSelection? PromptForDayAndPart()
    {
        var choices = Enumerable
            .Range(1, 14)
            .SelectMany(day => new[]
            {
                new PuzzleSelection(day, 1),
                new PuzzleSelection(day, 2),
            })
            .ToList();

        var prompt = new SelectionPrompt<PuzzleSelection>()
        {
            Title = "[yellow]Select [bold]day[/] and [bold]part[/]:[/]",
            PageSize = 10,
            MoreChoicesText = "[grey](Move up and down to see more days)[/]",
            HighlightStyle = new Style(
                foreground: Color.Black,
                background: Color.Yellow,
                decoration: Decoration.Bold),
            WrapAround = true
        };

        // How each choice is displayed
        prompt.UseConverter(p => p.ToString());

        // Add the Day/Part options
        prompt.AddChoices(choices);

        // Arrow keys + highlight are handled by SelectionPrompt internally
        return AnsiConsole.Prompt(prompt);
    }

    private static PuzzleInput PromptForPuzzleInput(PuzzleSelection selection)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"Selected [green]{selection}[/].");
        AnsiConsole.MarkupLine(
            "[bold]Provide Puzzle Input:[/]\n" +
            "- drag & drop your input file into the console and press [green]Enter[/]\n");

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

            // Drag-and-drop paths often come wrapped in quotes
            if ((line.StartsWith("\"") && line.EndsWith("\"")) ||
                (line.StartsWith("'") && line.EndsWith("'")))
            {
                line = line.Substring(1, line.Length - 2);
            }

            // If it's a file path, read the file
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

            throw new FileNotFoundException(line);
        }
    }

    // Example stub – wire this to your real AoC solutions
    private static void RunPuzzle(PuzzleSelection selection, string input)
    {
        // e.g. switch on (selection.Day, selection.Part)
        // and call your AdventOfCode2025.DayXPartY classes
        IDayPuzzle? puzzle = null;
        
        switch (selection.Day, selection.Part)
        {
            case (1, 1):
                puzzle = new Day1Part1(input);
                break;
        }

        if (puzzle != null)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[grey]To start calculating answer, press[/] [green]Enter[/].");
            Console.ReadLine();

            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[grey]Answer:[/] [yellow]{puzzle.GetAnswer()}[/]");
            AnsiConsole.MarkupLine($"[bold]Press any key to exit.[/]");
            Console.ReadLine();
        }
        else
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[grey]Puzzle not completed yet. Exiting.[/]");
        }
    }
}