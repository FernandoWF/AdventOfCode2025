namespace Solutions.Day03;

internal class Battery(char joltage, int indexInBank) : IComparable<Battery>
{
    public char RawJoltage => joltage;
    public int Joltage => RawJoltage - '0';
    public int IndexInBank => indexInBank;

    public int CompareTo(Battery? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Joltage.CompareTo(other.Joltage);
    }

    public override string ToString()
    {
        return $"#{indexInBank}: {joltage}";
    }
}
