namespace Solutions.Day10;

internal class Button(IReadOnlyList<int> indexesToToggle)
{
    public IReadOnlyList<int> IndexesToToggle { get; } = indexesToToggle;
}
