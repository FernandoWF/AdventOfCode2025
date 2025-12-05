using Solutions;
using Solutions.Day05;

namespace Tests;

public class Day05SolutionTests
{
    private static readonly Input ExampleInput = new("""
        3-5
        10-14
        16-20
        12-18

        1
        5
        8
        11
        17
        32
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(3, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(14L, Solution.RunPart2(ExampleInput));
    }
}
