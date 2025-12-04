namespace AdventOfCode2025.Day4;

public class Day4Part1
{
    public int Run(string[] input)
    {
        var width = input[0].Length;
        var height = input.Length;

        var hashMap = new int[width, height];

        for (var y = 0; y < height; y++)
        {
            var line = input[y];
            for (var x = 0; x < width; x++)
            {
                var currentCharacter = line[x];
                if (currentCharacter == '@')
                {
                    hashMap[x, y] = 1;
                }
            }
        }

        var accessedAmountOfPaper = 0;

        /*
         *  The forklifts can only access a roll of paper if there are fewer than four rolls of paper in the eight adjacent positions.
         * If you can figure out which rolls of paper the forklifts can access,
         * they'll spend less time looking and more time breaking down the wall to the cafeteria.
         * In this example, there are 13 rolls of paper that can be accessed by a forklift (marked with x):
         *
         */

        var arrWidth = hashMap.GetLength(0);
        var arrHeight = hashMap.GetLength(1);
        
        for (var y = 0; y < arrHeight; y++)
        {
            for (var x = 0; x < arrWidth; x++)
            {
                var currentValue = hashMap[x, y];

                if (currentValue == 1)
                {
                    // This is a "Roll of paper", now we need to check adjacent squares.
                    var leftValue = 0;
                    var rightValue = 0;
                    var upValue = 0;
                    var downValue = 0;

                    var topLeftValue = 0;
                    var topRightValue = 0;
                    var bottomLeftValue = 0;
                    var bottomRightValue = 0;

                    if (x - 1 >= 0)
                        leftValue = hashMap[x - 1, y] > 0 ? 1 : 0;

                    if (x + 1 < arrWidth)
                        rightValue = hashMap[x + 1, y] > 0 ? 1 : 0;

                    if (y + 1 < arrHeight)
                        upValue = hashMap[x, y + 1] > 0 ? 1 : 0;

                    if (y - 1 >= 0)
                        downValue = hashMap[x, y - 1] > 0 ? 1 : 0;

                    if (x - 1 >= 0 && y + 1 < arrHeight)
                        topLeftValue = hashMap[x - 1, y + 1] > 0 ? 1 : 0;

                    if (x + 1 < arrWidth && y + 1 < arrHeight)
                        topRightValue = hashMap[x + 1, y + 1] > 0 ? 1 : 0;

                    if (x - 1 >= 0 && y - 1 >= 0)
                        bottomLeftValue = hashMap[x - 1, y - 1] > 0 ? 1 : 0;

                    if (x + 1 < arrWidth && y - 1 >= 0)
                        bottomRightValue = hashMap[x + 1, y - 1] > 0 ? 1 : 0;

                    var totalRolls = leftValue + rightValue + upValue + downValue + topLeftValue + topRightValue +
                                     bottomLeftValue + bottomRightValue;

                    if (totalRolls < 4 && hashMap[x, y] != 2)
                    {
                        hashMap[x, y] = 2;
                        accessedAmountOfPaper++;
                    }
                }

                var printValue = hashMap[x, y];

                if (printValue == 0)
                {
                    Console.Write('.');
                }
                else if (printValue == 1)
                {
                    Console.Write('@');
                }
                else if (printValue == 2)
                {
                    Console.Write('x');
                }
            }

            Console.Write('\n');
        }

        return accessedAmountOfPaper;
    }
}