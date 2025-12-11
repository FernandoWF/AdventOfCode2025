using System.Text.RegularExpressions;

namespace Solutions.Day10;

internal sealed partial class Solution : ISolution
{
    [GeneratedRegex(@"\[[\.#]+\]")]
    private static partial Regex GetDiagramRegex();

    [GeneratedRegex(@"\([0-9]+(,[0-9]+)*\)")]
    private static partial Regex GetButtonRegex();

    public static object RunPart1(Input input)
    {
        var diagramRegex = GetDiagramRegex();
        var buttonRegex = GetButtonRegex();

        var machines = input.Lines
            .Select(line =>
            {
                var rawDiagram = diagramRegex.Match(line).Value;
                var rawButtons = new List<string>();

                var buttonMatch = buttonRegex.Match(line);
                while (buttonMatch.Success)
                {
                    rawButtons.Add(buttonMatch.Value);
                    buttonMatch = buttonMatch.NextMatch();
                }

                return new Machine(rawDiagram, rawButtons);
            })
            .ToArray();

        return machines.Sum(machine => machine.GetMinimumButtonPressesToCorrectlyConfigure());
    }

    public static object RunPart2(Input input)
    {
        return string.Empty;
    }
}
