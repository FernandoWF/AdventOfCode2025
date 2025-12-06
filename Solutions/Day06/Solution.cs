namespace Solutions.Day06;

internal sealed class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var operatorLineIndex = input.Lines.Length - 1;
        var operatorLine = input.Lines[operatorLineIndex];
        var lastColumn = operatorLine.Length - 1;

        var startingColumns = new List<int>();
        for (var index = 0; index <= lastColumn; index++)
        {
            if (operatorLine[index] == '+' || operatorLine[index] == '*')
            {
                startingColumns.Add(index);
            }
        }

        var grandTotal = 0L;

        // Just to simplify the loop, adds an artificial column at the end of the list
        // This way the loop starts at zero and ends when it reaches the artificial column
        startingColumns.Add(lastColumn + 2);

        for (var columnIndex = 0; columnIndex < startingColumns.Count - 1; columnIndex++)
        {
            var startingColumn = startingColumns[columnIndex];
            var endingColumn = startingColumns[columnIndex + 1] - 2;
            var @operator = operatorLine[startingColumn];

            var total = @operator == '+'
                ? 0L
                : 1L;

            for (var numberLineIndex = 0; numberLineIndex < operatorLineIndex; numberLineIndex++)
            {
                var rawNumber = input.Lines[numberLineIndex][startingColumn..(endingColumn + 1)];
                var number = int.Parse(rawNumber.Trim());

                if (@operator == '+')
                {
                    total += number;
                }
                else
                {
                    total *= number;
                }
            }

            grandTotal += total;
        }

        return grandTotal;
    }

    public static object RunPart2(Input input)
    {
        var operatorLineIndex = input.Lines.Length - 1;
        var operatorLine = input.Lines[operatorLineIndex];
        var lastColumn = operatorLine.Length - 1;

        var endingColumns = new List<int>();
        for (var index = 0; index <= lastColumn; index++)
        {
            if (operatorLine[index] == '+' || operatorLine[index] == '*')
            {
                endingColumns.Add(index);
            }
        }

        var grandTotal = 0L;

        // Just to simplify the loop, adds an artificial column at the end of the list
        // This way the loop starts at the artificial column and ends when it reaches zero
        endingColumns.Add(lastColumn + 2);

        for (var columnIndex = endingColumns.Count - 1; columnIndex > 0; columnIndex--)
        {
            var startingColumn = endingColumns[columnIndex] - 2;
            var endingColumn = endingColumns[columnIndex - 1];
            var @operator = operatorLine[endingColumn];

            var total = @operator == '+'
                ? 0L
                : 1L;

            for (var numberColumnIndex = startingColumn; numberColumnIndex >= endingColumn; numberColumnIndex--)
            {
                var rawNumber = string.Empty;
                for (var numberLineIndex = 0; numberLineIndex < operatorLineIndex; numberLineIndex++)
                {
                    rawNumber += input.Lines[numberLineIndex][numberColumnIndex];
                }

                var number = int.Parse(rawNumber.Trim());

                if (@operator == '+')
                {
                    total += number;
                }
                else
                {
                    total *= number;
                }
            }

            grandTotal += total;
        }

        return grandTotal;
    }
}
