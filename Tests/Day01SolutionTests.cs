using Solutions;
using Solutions.Day01;

namespace Tests;

public class Day01SolutionTests
{
    private static readonly Input ExampleInput = new("""
        
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(string.Empty, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(string.Empty, Solution.RunPart2(ExampleInput));
    }
}
