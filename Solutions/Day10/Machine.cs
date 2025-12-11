using System.Diagnostics;

namespace Solutions.Day10;

internal class Machine
{
    private uint currentState;
    private readonly uint targetState;
    private readonly Button[] buttons;
    private readonly Dictionary<int, bool> pressStateByButtonIndex;

    public Machine(string rawDiagram, IReadOnlyCollection<string> rawButtons)
    {
        var rawDiagramContents = rawDiagram[1..(rawDiagram.Length - 1)];

        for (var bitIndex = 0; bitIndex < rawDiagramContents.Length; bitIndex++)
        {
            if (rawDiagramContents[bitIndex] == '#')
            {
                targetState |= 1u << bitIndex;
            }
        }

        buttons = rawButtons
            .Select(rawButton =>
            {
                var indexesToPress = rawButton[1..(rawButton.Length - 1)]
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
                return new Button(indexesToPress);
            })
            .ToArray();

        pressStateByButtonIndex = Enumerable.Range(0, buttons.Length)
            .ToDictionary(buttonIndex => buttonIndex, _ => false);
    }

    public int GetMinimumButtonPressesToCorrectlyConfigure()
    {
        for (var remainingButtonPresses = 1; remainingButtonPresses <= buttons.Length; remainingButtonPresses++)
        {
            if (CanUnpressedButtonsCorrectlyConfigure(remainingButtonPresses))
            {
                return remainingButtonPresses;
            }
        }

        throw new UnreachableException("Machine should be able to be correctly configured.");
    }

    private bool CanUnpressedButtonsCorrectlyConfigure(int remainingButtonPresses)
    {
        if (remainingButtonPresses == 0)
        {
            return false;
        }

        if (DoesAnySingleUnpressedButtonCorrectlyConfigure())
        {
            return true;
        }

        foreach (var (buttonIndex, isPressed) in pressStateByButtonIndex)
        {
            if (!isPressed)
            {
                PressButton(buttonIndex);
                pressStateByButtonIndex[buttonIndex] = true;

                if (CanUnpressedButtonsCorrectlyConfigure(remainingButtonPresses - 1))
                {
                    return true;
                }

                PressButton(buttonIndex);
                pressStateByButtonIndex[buttonIndex] = false;
            }
        }

        return false;
    }

    private bool DoesAnySingleUnpressedButtonCorrectlyConfigure()
    {
        foreach (var (buttonIndex, isPressed) in pressStateByButtonIndex)
        {
            if (!isPressed)
            {
                PressButton(buttonIndex);
                var buttonCorrectlyConfigures = currentState == targetState;
                PressButton(buttonIndex);

                if (buttonCorrectlyConfigures)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void PressButton(int buttonIndex)
    {
        var button = buttons[buttonIndex];

        for (var indexIndex = 0; indexIndex < button.IndexesToToggle.Count; indexIndex++)
        {
            var bitIndex = button.IndexesToToggle[indexIndex];
            currentState ^= 1u << bitIndex;
        }
    }
}
