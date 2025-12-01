using Solutions;
using Solutions.Day01;

namespace Tests;

public class Day01SolutionTests
{
    private static readonly Input ExampleInput = new("""
        L68
        L30
        R48
        L5
        R60
        L55
        L1
        L99
        R14
        L82
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(3, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(6, Solution.RunPart2(ExampleInput));
    }
}
