namespace Solutions.Day04;

internal sealed class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var grid = input.ToMatrix(character => character == '@');
        var accessibleRolls = grid
            .Where(tuple => tuple.Value && IsRollAccessible(grid, tuple.X, tuple.Y))
            .ToList();

        return accessibleRolls.Count;
    }

    private static bool IsRollAccessible(Matrix<bool> grid, int rollX, int rollY)
    {
        var adjacentRolls = 0;

        for (var y = -1; y <= 1; y++)
        {
            for (var x = -1; x <= 1; x++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                if (grid.GetOrDefault(rollX + x, rollY + y))
                {
                    adjacentRolls++;
                }
            }
        }

        return adjacentRolls < 4;
    }

    public static object RunPart2(Input input)
    {
        var grid = input.ToMatrix(character => character == '@');
        var removedRolls = 0;
        var totalRemovedRolls = 0;

        do
        {
            removedRolls = 0;
            var accessibleRolls = grid
                .Where(tuple => tuple.Value && IsRollAccessible(grid, tuple.X, tuple.Y))
                .ToList();

            foreach (var (_, x, y) in accessibleRolls)
            {
                grid[x, y] = false;
                removedRolls++;
                totalRemovedRolls++;
            }
        }
        while (removedRolls > 0);

        return totalRemovedRolls;
    }
}
