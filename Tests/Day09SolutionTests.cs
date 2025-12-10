using Solutions;
using Solutions.Day09;

namespace Tests;

public class Day09SolutionTests
{
    private static readonly Input ExampleInput = new("""
        7,1
        11,1
        11,7
        9,7
        9,5
        2,5
        2,3
        7,3
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(50L, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(24L, Solution.RunPart2(ExampleInput));
    }
}
