namespace Solutions.Day05;

internal sealed class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var blankLineIndex = input.Lines.IndexOf(string.Empty);
        var rangeLines = input.Lines[..blankLineIndex];
        var idLines = input.Lines[(blankLineIndex + 1)..];
        var ranges = rangeLines
            .Select(line =>
            {
                var values = line.Split('-');
                return new Range(long.Parse(values[0]), long.Parse(values[1]));
            })
            .ToList();
        var ids = idLines
            .Select(long.Parse)
            .ToList();

        return ids
            .Where(id => ranges.Any(range => range.Contains(id)))
            .Count();
    }

    public static object RunPart2(Input input)
    {
        var blankLineIndex = input.Lines.IndexOf(string.Empty);
        var rangeLines = input.Lines[..blankLineIndex];
        var ranges = rangeLines
            .Select(line =>
            {
                var values = line.Split('-');
                return new Range(long.Parse(values[0]), long.Parse(values[1]));
            })
            .ToList();

        var nonOverlappingRanges = new List<Range>();
        for (var originalRangeIndex = 0; originalRangeIndex < ranges.Count; originalRangeIndex++)
        {
            var originalRange = ranges[originalRangeIndex];
            var effectiveRanges = new List<Range> { originalRange with { } };

            for (var effectiveRangeIndex = 0; effectiveRangeIndex < effectiveRanges.Count; effectiveRangeIndex++)
            {
                var newRanges = RemoveOverlaps(range: effectiveRanges[effectiveRangeIndex], previousRanges: nonOverlappingRanges);

                effectiveRanges.RemoveAt(effectiveRangeIndex);
                for (var newRangeIndex = 0; newRangeIndex < newRanges.Length; newRangeIndex++)
                {
                    effectiveRanges.Insert(effectiveRangeIndex + newRangeIndex, newRanges[newRangeIndex]);
                }

                if (newRanges.Length != 1)
                {
                    effectiveRangeIndex--;
                }
            }

            nonOverlappingRanges.AddRange(effectiveRanges);
        }

        return nonOverlappingRanges.Sum(range => range.Count);
    }

    private static Range[] RemoveOverlaps(Range range, List<Range> previousRanges)
    {
        var start = range.Start;
        var end = range.End;

        for (var previousRangeIndex = 0; previousRangeIndex < previousRanges.Count; previousRangeIndex++)
        {
            var previousRange = previousRanges[previousRangeIndex];

            if (previousRange.Start <= start)
            {
                if (previousRange.End < start)
                {
                    continue;
                }
                else
                {
                    start = previousRange.End + 1;
                }
            }

            if (previousRange.End >= end)
            {
                if (previousRange.Start > end)
                {
                    continue;
                }
                else
                {
                    end = previousRange.Start - 1;
                }
            }

            if (start > end)
            {
                break;
            }

            if (previousRange.Start > start && previousRange.End < end)
            {
                return [new Range(start, previousRange.Start - 1), new Range(previousRange.End + 1, end)];
            }
        }

        return start <= end
            ? [new Range(start, end)]
            : [];
    }
}
