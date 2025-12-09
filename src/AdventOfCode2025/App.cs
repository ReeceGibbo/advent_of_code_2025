using System.Diagnostics;
using AdventOfCode2025.Rendering;
using AdventOfCode2025.Screens;
using Spectre.Console;

namespace AdventOfCode2025;

public static class App
{
    public static void Run()
    {
        var screenStack = new Stack<IScreen>();
        screenStack.Push(new ScreenMainMenu());

        var running = true;

        var stopwatch = Stopwatch.StartNew();
        var lastTime = stopwatch.Elapsed;

        var hasRenderedAtLeastOnce = false;

        while (running && screenStack.Count > 0)
        {
            var current = screenStack.Peek();

            // --- 1. Time step for ticking screens ---
            var now = stopwatch.Elapsed;
            var delta = now - lastTime;
            lastTime = now;

            // First iteration: force a render
            var needsRender = !hasRenderedAtLeastOnce;

            if (current is IDynamicScreen ticking)
            {
                ticking.Update(delta);
                // Ticking screens want regular redraw
                needsRender = true;
            }

            // --- 2. Input handling (non-blocking) ---
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(intercept: true);

                // ✅ Any key press can potentially change UI → ask to re-render
                needsRender = true;

                // Global keys (work on any screen)
                if (keyInfo.Key is ConsoleKey.Q or ConsoleKey.Escape)
                {
                    running = false;
                }
                else if (keyInfo.Key is ConsoleKey.B)
                {
                    if (screenStack.Count > 1)
                        screenStack.Pop();
                }
                else
                {
                    // Let the current screen handle everything else
                    var command = current.HandleInput(keyInfo);

                    switch (command.Type)
                    {
                        case ScreenCommandType.None:
                            // nothing structural changed, but we still re-render
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

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            // Screen might have changed (push/pop), so re-peek
            current = screenStack.Peek();

            // --- 3. Render if needed (first frame, tick, or any key) ---
            if (needsRender)
            {
                AnsiConsole.Clear();
                RenderHeader(current.Title);
                current.Render();
                hasRenderedAtLeastOnce = true;
            }

            Thread.Sleep(100); // ~10 FPS
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

        AnsiConsoleExtensions.WriteCentered(
            "[grey]Keys: arrows to move, [b]Enter[/] to select, [b]B[/] back, [b]Q[/]/Esc quit.[/]");
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();
    }
}