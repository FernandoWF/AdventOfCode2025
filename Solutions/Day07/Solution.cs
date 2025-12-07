namespace Solutions.Day07;

internal sealed class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var startColumn = input.Lines[0].IndexOf('S');
        var diagram = input.ToRectangularMatrix();
        diagram[startColumn, 0] = '|';

        var splitCount = 0;

        for (var y = 1; y < diagram.Height; y++)
        {
            for (var x = 0; x < diagram.Width; x++)
            {
                if (diagram[x, y - 1] == '|')
                {
                    if (diagram[x, y] == '.')
                    {
                        diagram[x, y] = '|';
                    }
                    else if (diagram[x, y] == '^')
                    {
                        diagram[x - 1, y] = '|';
                        diagram[x + 1, y] = '|';
                        splitCount++;
                    }
                }
            }
        }

        return splitCount;
    }

    public static object RunPart2(Input input)
    {
        var startColumn = input.Lines[0].IndexOf('S');
        var originalDiagram = input.ToRectangularMatrix();
        originalDiagram[startColumn, 0] = '|';

        var timelineDiagram = new Matrix<long>(originalDiagram.Width, originalDiagram.Height);
        timelineDiagram[startColumn, 0] = 1;

        for (var y = 1; y < originalDiagram.Height; y++)
        {
            for (var x = 0; x < originalDiagram.Width; x++)
            {
                if (originalDiagram[x, y - 1] == '|')
                {
                    if (originalDiagram[x, y] == '^')
                    {
                        originalDiagram[x - 1, y] = '|';
                        timelineDiagram[x - 1, y] += timelineDiagram[x, y - 1];

                        originalDiagram[x + 1, y] = '|';
                        timelineDiagram[x + 1, y] += timelineDiagram[x, y - 1];
                    }
                    else
                    {
                        originalDiagram[x, y] = '|';
                        timelineDiagram[x, y] += timelineDiagram[x, y - 1];
                    }
                }
            }
        }

        return timelineDiagram
            .Where(tuple => tuple.Y == timelineDiagram.Height - 1)
            .Sum(tuple => tuple.Value);
    }
}
