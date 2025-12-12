namespace Solutions.Day12;

internal sealed partial class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var sections = input.Text.Split("\n\n");
        var shapeSections = sections[..^1];
        var treeRegionSection = sections[^1];

        var shapes = shapeSections
            .Select(section =>
            {
                var shapeText = section[(section.IndexOf('\n') + 1)..];
                return new Input(shapeText).ToMatrix(character => character is '#');
            })
            .ToArray();

        var treeRegions = treeRegionSection
            .Split('\n')
            .Select(rawTreeRegion =>
            {
                var xIndex = rawTreeRegion.IndexOf('x');
                var width = int.Parse(rawTreeRegion[..xIndex]);
                var colonIndex = rawTreeRegion.IndexOf(':');
                var height = int.Parse(rawTreeRegion[(xIndex + 1)..colonIndex]);
                var shapeCountByShapeIndex = rawTreeRegion[(colonIndex + 2)..]
                    .Split(' ')
                    .Select((shapeCount, shapeIndex) => (shapeCount, shapeIndex))
                    .ToDictionary(tuple => tuple.shapeIndex, tuple => int.Parse(tuple.shapeCount));

                return new TreeRegion(width, height, shapeCountByShapeIndex);
            })
            .ToArray();

        var fittableRegions = 0;
        foreach (var region in treeRegions)
        {
            var availableArea = region.Width * region.Height;
            var occupiedArea = region.ShapeCountByShapeIndex
                .Select(tuple =>
                {
                    var shapeIndex = tuple.Key;
                    var count = tuple.Value;

                    var shape = shapes[shapeIndex];

                    return shape.Where(tuple => tuple.Value).Count() * count;
                })
                .Sum();

            if (occupiedArea <= availableArea)
            {
                fittableRegions++;
            }
        }

        return fittableRegions;
    }

    public static object RunPart2(Input input)
    {
        return "There is no part 2!";
    }
}
