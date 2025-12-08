using System.Diagnostics;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace AdventOfCode2025;

public static class ConsoleUi
{
    public static void RunTimedProgress(
        string title,
        int maxValue,
        Action<ProgressTask> work)
    {
        var stopwatch = Stopwatch.StartNew();

        AnsiConsole.Progress()
            .Columns(
                new TaskDescriptionColumn(),
                new ProgressBarColumn(),
                new CountColumn(), // 👈 our X/TOTAL column
                new RemainingTimeColumn(),
                new SpinnerColumn())
            .Start(ctx =>
            {
                var task = ctx.AddTask($"[green]{title}[/]", maxValue: maxValue);
                work(task);
            });

        stopwatch.Stop();

        var elapsed = stopwatch.Elapsed;
        AnsiConsole.MarkupLine(
            $"[grey]{title} completed in[/] [yellow]{elapsed:mm\\:ss\\.fff}[/]");
    }
}

public sealed class CountColumn : ProgressColumn
{
    public override IRenderable Render(RenderOptions options, ProgressTask task, TimeSpan deltaTime)
    {
        // You can tweak formatting here if you want padding etc.
        var text = $"{task.Value}/{task.MaxValue}";
        return new Text(text, new Style(Color.Grey));
    }
}