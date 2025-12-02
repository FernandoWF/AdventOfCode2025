namespace Solutions.Day02;

internal sealed class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var rawRanges = input.Text.Split(',');
        var ranges = rawRanges
            .Select(rawRange =>
            {
                var numbers = rawRange.Split('-');
                return new Range(long.Parse(numbers[0]), long.Parse(numbers[1]));
            })
            .ToList();
        var invalidIds = new List<long>();

        foreach (var range in ranges)
        {
            for (var id = range.First; id <= range.Last; id++)
            {
                var idText = id.ToString();

                if (idText.Length % 2 != 0)
                {
                    continue;
                }

                var halfSize = idText.Length / 2;
                var firstHalf = idText[..halfSize];
                var secondHalf = idText[halfSize..];

                if (firstHalf == secondHalf)
                {
                    invalidIds.Add(id);
                }
            }
        }

        return invalidIds.Sum();
    }

    public static object RunPart2(Input input)
    {
        var rawRanges = input.Text.Split(',');
        var ranges = rawRanges
            .Select(rawRange =>
            {
                var numbers = rawRange.Split('-');
                return new Range(long.Parse(numbers[0]), long.Parse(numbers[1]));
            })
            .ToList();
        var invalidIds = new List<long>();

        foreach (var range in ranges)
        {
            for (var id = range.First; id <= range.Last; id++)
            {
                var idText = id.ToString();

                for (var size = 1; size <= idText.Length / 2; size++)
                {
                    var pattern = idText[..size];
                    var sequence = pattern;

                    if (idText.Length % size != 0)
                    {
                        continue;
                    }

                    do
                    {
                        sequence += pattern;
                    }
                    while (sequence.Length < idText.Length);

                    if (sequence == idText)
                    {
                        invalidIds.Add(id);
                        break;
                    }
                }
            }
        }

        return invalidIds.Sum();
    }
}
