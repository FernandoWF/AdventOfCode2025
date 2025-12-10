namespace Solutions.Day09;

internal sealed class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var redTiles = input.Lines
            .Select(line =>
            {
                var coordinates = line.Split(',');
                return new Tile(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            })
            .ToList();

        var biggestArea = 0L;
        foreach (var tile in redTiles)
        {
            foreach (var otherTile in redTiles)
            {
                var rectangle = new Rectangle(tile, otherTile);

                if (rectangle.Area > biggestArea)
                {
                    biggestArea = rectangle.Area;
                }
            }
        }

        return biggestArea;
    }

    public static object RunPart2(Input input)
    {
        var redTiles = input.Lines
            .Select(line =>
            {
                var coordinates = line.Split(',');
                return new Tile(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
            })
            .ToList();

        var polygonPerimeter = new Perimeter(redTiles);
        var biggestValidArea = 0L;

        foreach (var tile in redTiles)
        {
            foreach (var otherTile in redTiles)
            {
                var minimumX = Math.Min(tile.X, otherTile.X);
                var maximumX = Math.Max(tile.X, otherTile.X);
                var minimumY = Math.Min(tile.Y, otherTile.Y);
                var maximumY = Math.Max(tile.Y, otherTile.Y);
                var width = maximumX - minimumX + 1;
                var height = maximumY - minimumY + 1;
                var isCompletelyInsidePolygon = true;

                if (width > 2 && height > 2)
                {
                    var innerMinimumX = minimumX + 1;
                    var innerMaximumX = maximumX - 1;
                    var innerMinimumY = minimumY + 1;
                    var innerMaximumY = maximumY - 1;
                    var topLeftCorner = new Tile(innerMinimumX, innerMinimumY);
                    var topRightCorner = new Tile(innerMaximumX, innerMinimumY);
                    var bottomLeftCorner = new Tile(innerMinimumX, innerMaximumY);
                    var bottomRightCorner = new Tile(innerMaximumX, innerMaximumY);
                    var innerPerimeter = new Perimeter([topLeftCorner, topRightCorner, bottomRightCorner, bottomLeftCorner]);

                    foreach (var polygonPerimeterLine in polygonPerimeter.Lines)
                    {
                        if (innerPerimeter.Lines.Any(innerPerimeterLine => innerPerimeterLine.Overlaps(polygonPerimeterLine)))
                        {
                            isCompletelyInsidePolygon = false;
                            break;
                        }
                    }
                }

                if (isCompletelyInsidePolygon)
                {
                    var area = new Rectangle(tile, otherTile).Area;
                    if (area > biggestValidArea)
                    {
                        biggestValidArea = area;
                    }
                }
            }
        }

        return biggestValidArea;
    }
}
