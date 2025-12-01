namespace Solutions.Day01;

internal record Rotation
{
    public bool GoesTowardsLeft { get; }
    public bool GoesTowardsRight => !GoesTowardsLeft;
    public int Amount { get; }

    public Rotation(char direction, int amount)
    {
        GoesTowardsLeft = direction switch
        {
            'L' => true,
            'R' => false,
            _ => throw new ArgumentOutOfRangeException(nameof(direction))
        };
        Amount = amount;
    }
}
