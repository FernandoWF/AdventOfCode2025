namespace Solutions.Day09;

internal readonly record struct Rectangle(Tile FirstCorner, Tile SecondCorner)
{
    public long Area { get; } = (Math.Abs(FirstCorner.X - SecondCorner.X) + 1L) * (Math.Abs(FirstCorner.Y - SecondCorner.Y) + 1L);
}
