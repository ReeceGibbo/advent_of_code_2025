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
    
    // PART 2
    [Test]
    public void Test5()
    {
        var day3 = new Day3Part2();

        var query = "987654321111111";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(987654321111));
    }

    [Test]
    public void Test6()
    {
        var day3 = new Day3Part2();

        var query = "811111111111119";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(811111111119));
    }

    [Test]
    public void Test7()
    {
        var day3 = new Day3Part2();

        var query = "234234234234278";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(434234234278));
    }

    [Test]
    public void Test8()
    {
        var day3 = new Day3Part2();

        var query = "818181911112111";
        var result = day3.GetValue(query);

        Assert.That(result, Is.EqualTo(888911112111));
    }
}