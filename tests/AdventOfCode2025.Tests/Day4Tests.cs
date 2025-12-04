using System.Text;
using AdventOfCode2025.Day4;

namespace AdventOfCode2025.Tests;

public class Day4Tests
{
    [Test]
    public void Test1()
    {
        var day4 = new Day4Part1();

        var data = new StringBuilder().Append("""
..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.
""")
            .ToString();

        var query = data.Replace("\r", "").Split('\n');
        var value = day4.Run(query);
        
        Assert.That(value, Is.EqualTo(13));
    }

    [Test]
    public void Test2()
    {
        var day4 = new Day4Part2();

        var data = new StringBuilder().Append("""
..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.
""")
            .ToString();

        var query = data.Replace("\r", "").Split('\n');
        var value = day4.Run(query);

        Assert.That(value, Is.EqualTo(43));
    }
}