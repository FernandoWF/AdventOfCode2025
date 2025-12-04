namespace Solutions;

internal class Input(string text)
{
    public string Text { get; } = text;
    public string[] Lines { get; } = text.Split('\n');

    public Matrix<char> ToRectangularMatrix()
    {
        return ToMatrix(character => character);
    }

    public Matrix<int> ToRectangularIntegerMatrix()
    {
        return ToMatrix(character => (int)char.GetNumericValue(character));
    }

    public Matrix<T> ToMatrix<T>(Func<char, T> transformation)
    {
        var height = Lines.Length;
        var width = Lines[0].Length;
        var matrix = new Matrix<T>(width, height);

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                matrix[x, y] = transformation(Lines[y][x]);
            }
        }

        return matrix;
    }
}
