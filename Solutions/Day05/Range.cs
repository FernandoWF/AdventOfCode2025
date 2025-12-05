namespace Solutions.Day05;

internal readonly record struct Range(long Start, long End)
{
    public long Count => End - Start + 1;

    public bool Contains(long value) => value >= Start && value <= End;
};
