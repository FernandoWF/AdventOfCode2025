namespace Solutions.Day01;

internal sealed class Solution : ISolution
{
    private const int NumberCount = 100;

    public static object RunPart1(Input input)
    {
        var currentNumber = 50;
        var timesReachedZero = 0;

        foreach (var line in input.Lines)
        {
            var rotation = new Rotation(direction: line[0], amount: int.Parse(line[1..]));
            var amount = rotation.GoesTowardsLeft
                ? -rotation.Amount
                : rotation.Amount;

            currentNumber = (currentNumber + amount + NumberCount) % NumberCount;

            if (currentNumber == 0)
            {
                timesReachedZero++;
            }
        }

        return timesReachedZero;
    }

    public static object RunPart2(Input input)
    {
        var currentNumber = 50;
        var timesPassedZero = 0;

        foreach (var line in input.Lines)
        {
            var rotation = new Rotation(direction: line[0], amount: int.Parse(line[1..]));
            var increment = rotation.GoesTowardsLeft
                ? -1
                : 1;

            for (var i = 0; i < rotation.Amount; i++)
            {
                currentNumber = (currentNumber + increment + NumberCount) % NumberCount;

                if (currentNumber == 0)
                {
                    timesPassedZero++;
                }
            }
        }

        return timesPassedZero;
    }
}
