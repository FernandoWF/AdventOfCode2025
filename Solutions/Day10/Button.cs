namespace Solutions.Day10;

internal class Button(IReadOnlyList<int> indexesToChange)
{
    public IReadOnlyList<int> IndexesToChange { get; } = indexesToChange;
}
