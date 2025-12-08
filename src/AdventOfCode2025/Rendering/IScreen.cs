namespace AdventOfCode2025.Rendering;

public interface IScreen
{
    string Title { get; }
    void Render();
    ScreenCommand HandleInput(ConsoleKeyInfo key);
}