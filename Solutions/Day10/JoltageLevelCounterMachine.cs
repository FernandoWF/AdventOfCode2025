using Microsoft.Z3;
using System.Diagnostics;

namespace Solutions.Day10;

internal class JoltageLevelCounterMachine(string rawJoltageLevelCounters, IReadOnlyCollection<string> rawButtons)
{
    private readonly int[] targetJoltageLevelCounterValues = rawJoltageLevelCounters[1..(rawJoltageLevelCounters.Length - 1)]
        .Split(',')
        .Select(int.Parse)
        .ToArray();

    private readonly Button[] buttons = rawButtons
        .Select(rawButton =>
        {
            var indexesToIncrement = rawButton[1..(rawButton.Length - 1)]
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            return new Button(indexesToIncrement);
        })
        .ToArray();

    public int GetMinimumButtonPressesToCorrectlyConfigure()
    {
        using var context = new Context();
        var optimize = context.MkOptimize();

        var variableByButtonIndex = Enumerable.Range(0, buttons.Length)
            .ToDictionary(
                buttonIndex => buttonIndex,
                buttonIndex => context.MkIntConst($"button_{buttonIndex}_press_count"));

        foreach (var variable in variableByButtonIndex.Values)
        {
            var nonNegativeVariableConstraint = context.MkGe(variable, context.MkInt(0));
            optimize.Assert(nonNegativeVariableConstraint);
        }

        for (var joltageLevelCounterIndex = 0; joltageLevelCounterIndex < targetJoltageLevelCounterValues.Length; joltageLevelCounterIndex++)
        {
            var joltageLevelCounterValue = targetJoltageLevelCounterValues[joltageLevelCounterIndex];

            var variablesInExpression = variableByButtonIndex
                .Where(pair => buttons[pair.Key].IndexesToChange.Contains(joltageLevelCounterIndex))
                .Select(pair => pair.Value)
                .ToArray();
            var expression = context.MkAdd(variablesInExpression);

            var equation = context.MkEq(expression, context.MkInt(joltageLevelCounterValue));
            optimize.Assert(equation);
        }

        var sumOfAllButtonPressesExpression = context.MkAdd(variableByButtonIndex.Values);
        var objective = optimize.MkMinimize(sumOfAllButtonPressesExpression);

        if (optimize.Check() is not Status.SATISFIABLE)
        {
            throw new UnreachableException("All constraints should have been able to be satisfied.");
        }

        if (objective.Value is not IntNum result)
        {
            throw new UnreachableException("Result should have been an integer number.");
        }

        return result.Int;
    }
}
