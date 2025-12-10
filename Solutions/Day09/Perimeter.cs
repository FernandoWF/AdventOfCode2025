namespace Solutions.Day09;

internal class Perimeter
{
    public IReadOnlySet<Line> Lines { get; }

    public Perimeter(IReadOnlyList<Tile> polygonCornersInCycleOrder)
    {
        var lines = new HashSet<Line>();
        for (var i = 0; i < polygonCornersInCycleOrder.Count; i++)
        {
            var source = polygonCornersInCycleOrder[i];
            var target = polygonCornersInCycleOrder[(i + 1) % polygonCornersInCycleOrder.Count];

            lines.Add(new Line(source, target));
        }

        Lines = lines;
    }
}
