namespace AdventOfCode2025.Rendering;

public enum ScreenCommandType
{
    None,
    PushScreen,
    PopScreen,
    Exit,
}
    
public sealed class ScreenCommand
{
    public ScreenCommandType Type { get; }
    public IScreen? ScreenToPush { get; }

    private ScreenCommand(ScreenCommandType type, IScreen? screenToPush = null)
    {
        Type = type;
        ScreenToPush = screenToPush;
    }

    public static ScreenCommand None() => new(ScreenCommandType.None);
    public static ScreenCommand Push(IScreen screen) => new(ScreenCommandType.PushScreen, screen);
    public static ScreenCommand Pop() => new(ScreenCommandType.PopScreen);
    public static ScreenCommand ExitApp() => new(ScreenCommandType.Exit);
}