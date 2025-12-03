namespace Solutions.Day03;

internal sealed class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        return GetBankJoltages(input, batteriesToPick: 2).Sum();
    }

    private static List<long> GetBankJoltages(Input input, int batteriesToPick)
    {
        var banks = input.Lines
            .Select(bank => bank
                .Select((joltage, index) => new Battery(joltage, index))
                .ToList())
            .ToList();
        var bankJoltages = banks
            .Select(bank =>
            {
                var biggestJoltageBattery = new Battery('\0', -1);
                var rawJoltage = string.Empty;

                for (var i = 0; i < batteriesToPick; i++)
                {
                    var subBank = bank[(biggestJoltageBattery.IndexInBank + 1)..^(batteriesToPick - 1 - i)];
                    var biggestJoltage = subBank.Max(battery => battery.Joltage)!;
                    biggestJoltageBattery = subBank.First(battery => battery.Joltage == biggestJoltage);
                    rawJoltage += biggestJoltageBattery.RawJoltage;
                }

                return long.Parse(rawJoltage);
            })
            .ToList();

        return bankJoltages;
    }

    public static object RunPart2(Input input)
    {
        return GetBankJoltages(input, batteriesToPick: 12).Sum();
    }
}
