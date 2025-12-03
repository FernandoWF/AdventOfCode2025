using Solutions;
using Solutions.Day03;

namespace Tests;

public class Day03SolutionTests
{
    private static readonly Input ExampleInput = new("""
        987654321111111
        811111111111119
        234234234234278
        818181911112111
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(357, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(3121910778619L, Solution.RunPart2(ExampleInput));
    }
}
