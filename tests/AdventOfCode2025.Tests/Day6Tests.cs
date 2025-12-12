using AdventOfCode2025.Day5;
using AdventOfCode2025.Day6;
using AdventOfCode2025.Rendering;

namespace AdventOfCode2025.Tests;

public class Day6Tests
{
    [Test]
    public void Part1()
    {
        var text = File.ReadAllText("E:\\Github\\advent_of_code_2025\\puzzle_inputs\\day6_input.txt");

        var day6 = new Day6Part1(new PuzzleInput(text, 0, 0, null));
        var answer = day6.GetAnswer();

        // var query = "11-22";
        // var result = day2.GetInvalidIds(query).Count;
        //
        // Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void Part2()
    {
        var text = File.ReadAllText("E:\\Github\\advent_of_code_2025\\puzzle_inputs\\day6_input.txt");

        var day6 = new Day6Part2(new PuzzleInput(text, 0, 0, null));
        var answer = day6.GetAnswer();

        // var query = "11-22";
        // var result = day2.GetInvalidIds(query).Count;
        //
        // Assert.That(result, Is.EqualTo(2));
    }
}