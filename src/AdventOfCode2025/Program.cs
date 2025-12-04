// See https://aka.ms/new-console-template for more information

using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;

namespace AdventOfCode2025;

public class Program
{
    public static void Main(string[] args)
    {
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
        
        var path = Path.Combine(baseDir, "puzzle_inputs", "day3_input.txt");
        
        if (!File.Exists(path))
        {
            Console.WriteLine($"File not found: {path}");
            return;
        }
        
        var text = File.ReadAllText(path);
        var splitText = text.Trim().Split('\n');
        
        var day3Test = new Day3Part1();
        var day3Result = day3Test.Run(splitText);
        
        Console.WriteLine($"Password: {day3Result}");
    }
}