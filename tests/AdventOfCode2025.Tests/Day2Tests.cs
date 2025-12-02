using AdventOfCode2025.Day2;

namespace AdventOfCode2025.Tests;

public class Day2Tests
{
    [Test]
    public void Test1()
    {
        var day2 = new Day2Part1();

        var query = "11-22";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Test2()
    {
        var day2 = new Day2Part1();

        var query = "95-115";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test3()
    {
        var day2 = new Day2Part1();

        var query = "1188511880-1188511890";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test4()
    {
        var day2 = new Day2Part1();

        var query = "222220-222224";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test5()
    {
        var day2 = new Day2Part1();

        var query = "1698522-1698528";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test6()
    {
        var day2 = new Day2Part1();

        var query = "446443-446449";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test7()
    {
        var day2 = new Day2Part1();

        var query = "38593856-38593862";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test8()
    {
        var day2 = new Day2Part1();

        var query =
            "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
                .Split(',');
        day2.Run(query);

        Assert.That(day2.GetFinalComputedValue(), Is.EqualTo(1227775554));
    }
    
    [Test]
    public void Test9()
    {
        var day2 = new Day2Part2();

        var query =
            "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"
                .Split(',');
        day2.Run(query);

        Assert.That(day2.GetFinalComputedValue(), Is.EqualTo(4174379265));
    }
    
    [Test]
    public void Test10()
    {
        var day2 = new Day2Part2();

        var query = "565653-565659";
        var result = day2.GetInvalidIds(query).Count;

        Assert.That(result, Is.EqualTo(1));
    }
}