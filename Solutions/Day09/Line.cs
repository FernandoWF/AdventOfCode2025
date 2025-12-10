namespace Solutions.Day09;

internal readonly record struct Line
{
    private enum Orientation { Horizontal, Vertical }

    private readonly Orientation orientation;
    private readonly Tile firstTile;
    private readonly Tile lastTile;

    public Line(Tile firstTile, Tile lastTile)
    {
        if (firstTile.X == lastTile.X)
        {
            var minimumY = Math.Min(firstTile.Y, lastTile.Y);
            var maximumY = Math.Max(firstTile.Y, lastTile.Y);

            orientation = Orientation.Vertical;
            this.firstTile = new(firstTile.X, minimumY);
            this.lastTile = new(firstTile.X, maximumY);
        }
        else if (firstTile.Y == lastTile.Y)
        {
            var minimumX = Math.Min(firstTile.X, lastTile.X);
            var maximumX = Math.Max(firstTile.X, lastTile.X);

            orientation = Orientation.Horizontal;
            this.firstTile = new(minimumX, firstTile.Y);
            this.lastTile = new(maximumX, firstTile.Y);
        }
        else
        {
            throw new ArgumentException("Line cannot be diagonal.");
        }
    }

    public bool Overlaps(Line other)
    {
        if (orientation == Orientation.Horizontal)
        {
            if (other.orientation == Orientation.Horizontal && firstTile.Y == other.firstTile.Y)
            {
                return (other.firstTile.X <= firstTile.X && other.lastTile.X >= firstTile.X)
                    || (other.firstTile.X <= lastTile.X && other.lastTile.X >= lastTile.X)
                    || (other.firstTile.X >= firstTile.X && other.lastTile.X <= lastTile.X);
            }

            return other.firstTile.X >= firstTile.X
                && other.firstTile.X <= lastTile.X
                && firstTile.Y >= other.firstTile.Y
                && firstTile.Y <= other.lastTile.Y;
        }
        else
        {
            if (other.orientation == Orientation.Vertical && firstTile.X == other.firstTile.X)
            {
                return (other.firstTile.Y <= firstTile.Y && other.lastTile.Y >= firstTile.Y)
                    || (other.firstTile.Y <= lastTile.Y && other.lastTile.Y >= lastTile.Y)
                    || (other.firstTile.Y >= firstTile.Y && other.lastTile.Y <= lastTile.Y);
            }

            return other.firstTile.Y >= firstTile.Y
                && other.firstTile.Y <= lastTile.Y
                && firstTile.X >= other.firstTile.X
                && firstTile.X <= other.lastTile.X;
        }
    }
}
