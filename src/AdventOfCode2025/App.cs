using AdventOfCode2025.Rendering;
using AdventOfCode2025.Screens;
using Spectre.Console;

public static class App
{
    public static void Run()
    {
        var screenStack = new Stack<IScreen>();
        screenStack.Push(new ScreenMainMenu());

        var running = true;

        while (running && screenStack.Count > 0)
        {
            var current = screenStack.Peek();

            AnsiConsole.Clear();
            RenderHeader(current.Title);
            current.Render();

            // No prompt / ReadLine anymore – we work on key presses
            var keyInfo = Console.ReadKey(intercept: true);

            // Global keys (work on any screen)
            if (keyInfo.Key is ConsoleKey.Q or ConsoleKey.Escape)
            {
                running = false;
                continue;
            }

            if (keyInfo.Key is ConsoleKey.B)
            {
                if (screenStack.Count > 1)
                    screenStack.Pop();
                continue;
            }

            // Let the current screen handle everything else
            var command = current.HandleInput(keyInfo);

            switch (command.Type)
            {
                case ScreenCommandType.None:
                    break;

                case ScreenCommandType.PushScreen:
                    if (command.ScreenToPush != null)
                        screenStack.Push(command.ScreenToPush);
                    break;

                case ScreenCommandType.PopScreen:
                    if (screenStack.Count > 1)
                        screenStack.Pop();
                    break;

                case ScreenCommandType.Exit:
                    running = false;
                    break;
            }
        }
    }

    private static void RenderHeader(string currentTitle)
    {
        AnsiConsole.Write(
            new FigletText("Advent Shell")
                .Centered()
                .Color(Color.Cyan1));

        var rule = new Rule($"[yellow]{currentTitle}[/]");
        rule.Justification = Justify.Center;
        AnsiConsole.Write(rule);

        var centered =
            Align.Center(
                new Markup("[grey]Keys: arrows to move, [b]Enter[/] to select, [b]B[/] back, [b]Q[/]/Esc quit.[/]\n"),
                VerticalAlignment.Top);
        AnsiConsole.Write(centered);
        AnsiConsole.WriteLine();
    }
}