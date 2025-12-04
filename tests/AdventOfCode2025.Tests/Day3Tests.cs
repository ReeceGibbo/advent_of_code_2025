using AdventOfCode2025.Day3;

namespace AdventOfCode2025.Tests;

public class Day3Tests
{
    [Test]
    public void Test1()
    {
        var day3 = new Day3Part1();

        var query = "987654321111111";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(98));
    }

    [Test]
    public void Test2()
    {
        var day3 = new Day3Part1();

        var query = "811111111111119";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(89));
    }

    [Test]
    public void Test3()
    {
        var day3 = new Day3Part1();

        var query = "234234234234278";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(78));
    }

    [Test]
    public void Test4()
    {
        var day3 = new Day3Part1();

        var query = "818181911112111";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(92));
    }
}