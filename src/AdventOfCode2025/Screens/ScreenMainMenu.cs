using AdventOfCode2025.Rendering;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace AdventOfCode2025.Screens;

public class ScreenMainMenu : IScreen
{
    public string Title => "Main Menu";

    private const int TotalDays = 25;
    private const int Cols = 4;
    private readonly int _rows = (int)Math.Ceiling(TotalDays / (double)Cols);

    private int _selectedIndex = 0; // 0 = Day 1

    public void Render()
    {
        var grid = new Grid();

        for (var i = 0; i < Cols; i++)
            grid.AddColumn(new GridColumn().Centered());

        for (var r = 0; r < _rows; r++)
        {
            var cells = new List<IRenderable>();

            for (var c = 0; c < Cols; c++)
            {
                var index = r * Cols + c; // 0-based index
                var day = index + 1;

                if (day > TotalDays)
                {
                    cells.Add(new Text(string.Empty));
                    continue;
                }

                var isSelected = index == _selectedIndex;

                // Add a bit of internal padding in the label itself
                var label =
                    isSelected
                        ? $"[black on yellow]  Day {day}  [/]"
                        : $"[white]  Day {day}  [/]";

                // Then pad the whole cell left/right to space columns out
                var padded = new Padder(
                    new Markup(label),
                    new Padding(left: 1, top: 0, right: 1, bottom: 0));

                cells.Add(padded);
            }

            grid.AddRow(cells.ToArray());
        }

        AnsiConsole.Write(Align.Center(grid.Collapse(), VerticalAlignment.Top));
    }

    public ScreenCommand HandleInput(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.LeftArrow:
                MoveLeft();
                return ScreenCommand.None();

            case ConsoleKey.RightArrow:
                MoveRight();
                return ScreenCommand.None();

            case ConsoleKey.UpArrow:
                MoveUp();
                return ScreenCommand.None();

            case ConsoleKey.DownArrow:
                MoveDown();
                return ScreenCommand.None();

            case ConsoleKey.Enter:
            {
                var day = _selectedIndex + 1;
                var input = PuzzleInputReader.RequestPuzzleInput(day, part: null);
                return ScreenCommand.Push(new ScreenDayPartSelection(day, input));
            }

            case ConsoleKey.B:
                return ScreenCommand.Pop();

            case ConsoleKey.Q:
                return ScreenCommand.ExitApp();

            default:
                return ScreenCommand.None();
        }
    }

    private void MoveLeft()
    {
        if (_selectedIndex % Cols > 0)
            _selectedIndex--;
    }

    private void MoveRight()
    {
        if (_selectedIndex % Cols < Cols - 1 &&
            _selectedIndex < TotalDays - 1)
            _selectedIndex++;
    }

    private void MoveUp()
    {
        if (_selectedIndex - Cols >= 0)
            _selectedIndex -= Cols;
    }

    private void MoveDown()
    {
        if (_selectedIndex + Cols < TotalDays)
            _selectedIndex += Cols;
    }
}