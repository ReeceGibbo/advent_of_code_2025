namespace AdventOfCode2025;

public class Day1Old
{
    private int _rotation = 50;
    private int _pointedAtZero = 0;
    private int _pointedAtZeroDuringSpin = 0;

    public int GetPassword()
    {
        return _pointedAtZero;
    }

    public int GetPassword_Part2()
    {
        return _pointedAtZeroDuringSpin;
    }

    public void Run(string[] input)
    {
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var decider = line[..1];
            var number = int.Parse(line[1..]);

            switch (decider)
            {
                case "R":
                    Rotate(true, number);
                    break;
                case "L":
                    Rotate(false, number);
                    break;
                default:
                    throw new Exception($"Unknown decider '{decider}'");
            }
        }
    }

    private void Rotate(bool right, int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            if (right)
            {
                _rotation += 1;
            }
            else
            {
                _rotation -= 1;
            }

            if (_rotation == 100)
            {
                _rotation = 0;
            }
            if (_rotation == -1)
            {
                _rotation = 99;
            }

            if (_rotation == 0)
            {
                _pointedAtZeroDuringSpin++;
            }
        }
        
        if (_rotation == 0)
            _pointedAtZero++;
    }
}