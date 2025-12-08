// namespace AdventOfCode2025.Tests;
//
// public class Tests
// {
//     [SetUp]
//     public void Setup()
//     {
//     }
//
//     [Test]
//     public void Test1()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             "L68",
//             "L30",
//             "R48",
//             "L5",
//             "R60",
//             "L55",
//             "L1",
//             "L99",
//             "R14",
//             "L82"
//         };
//         
//         day1.Run(data);
//         var password = day1.GetPassword();
//         
//         Assert.That(password, Is.EqualTo(3));
//     }
//     
//     [Test]
//     public void Test2()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             "L50",
//         };
//         
//         day1.Run(data);
//         var password = day1.GetPassword();
//         
//         Assert.That(password, Is.EqualTo(1));
//     }
//     
//     [Test]
//     public void Test3()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             "R50",
//         };
//         
//         day1.Run(data);
//         var password = day1.GetPassword();
//         
//         Assert.That(password, Is.EqualTo(1));
//     }
//     
//     [Test]
//     public void Test4()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             "R1000",
//         };
//         
//         day1.Run(data);
//         var password = day1.GetPassword_Part2();
//         
//         Assert.That(password, Is.EqualTo(10));
//     }
//     
//     [Test]
//     public void Test_Should_CountZeroHitsCorrectly_WhenCrossingMultipleZeros()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             "R250"  // from 50, spin right 250 clicks (2.5 full rotations)
//         };
//
//         day1.Run(data);
//         var password = day1.GetPassword_Part2();
//
//         // Expected: crosses 0 twice (every 100 clicks) at click 50->150->250
//         // -> positions at clicks 100 and 200 correspond to 0
//         // So total = 2 zeros during the spin
//         // And then it lands on 0 so counts as 3
//         Assert.That(password, Is.EqualTo(3));
//     }
//     
//     [Test]
//     public void MixedRotations_Should_MatchClickSimulation()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             "R150", // from 50: hits 0 twice
//             "L75",  // from 0 : never hits 0
//             "R125"  // from 25: hits 0 once
//         };
//
//         day1.Run(data);
//
//         Assert.That(day1.GetPassword(), Is.EqualTo(1)); // only R150 ends on 0
//         Assert.That(day1.GetPassword_Part2(), Is.EqualTo(3)); // 2 + 0 + 1 = 3 total hits
//     }
//     
//     [Test]
//     public void VeryComplicated_MixedRotations_Should_HitExpectedZeros()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             // Start at 50 (per AoC rules)
//             "R250", // from 50 -> 0, hits 0 three times (after 50, 150, 250 clicks)
//             "L380", // from 0  -> 20, hits 0 three times (at 100, 200, 300 clicks)
//             "R55",  // from 20 -> 75, hits 0 zero times (no wrap)
//             "L125", // from 75 -> 50, hits 0 once
//             "R999", // from 50 -> 49, hits 0 ten times
//             "L1"    // from 49 -> 48, hits 0 zero times
//         };
//
//         day1.Run(data);
//
//         // Part 1 – end-of-rotation zeros:
//         //   R250  ends at 0   → yes  (1)
//         //   L380  ends at 20  → no
//         //   R55   ends at 75  → no
//         //   L125  ends at 50  → no
//         //   R999  ends at 49  → no
//         //   L1    ends at 48  → no
//         // Total: 1
//         Assert.That(day1.GetPassword(), Is.EqualTo(1));
//
//         // Part 2 – every click that lands on 0:
//         //   R250  → 3 zeros
//         //   L380  → 3 zeros
//         //   R55   → 0 zeros
//         //   L125  → 1 zero
//         //   R999  → 10 zeros
//         //   L1    → 0 zeros
//         // Total = 3 + 3 + 0 + 1 + 10 + 0 = 17
//         Assert.That(day1.GetPassword_Part2(), Is.EqualTo(17));
//     }
//     
//     [Test]
//     public void Single_R50_Should_HitZero_Once()
//     {
//         var day1 = new Day1();
//
//         var data = new[]
//         {
//             "R50"
//         };
//
//         day1.Run(data);
//
//         Assert.That(day1.GetPassword(), Is.EqualTo(1));      // ends on 0
//         Assert.That(day1.GetPassword_Part2(), Is.EqualTo(1)); // only one click lands on 0
//     }
//
// }