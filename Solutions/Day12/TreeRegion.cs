namespace Solutions.Day12;

internal class TreeRegion(int width, int height, IReadOnlyDictionary<int, int> shapeCountByShapeIndex)
{
    public int Width { get; } = width;
    public int Height { get; } = height;
    public IReadOnlyDictionary<int, int> ShapeCountByShapeIndex { get; } = shapeCountByShapeIndex;
}
