using Solutions;
using Solutions.Day06;

namespace Tests;

public class Day06SolutionTests
{
    private static readonly Input ExampleInput = new("""
        123 328  51 64 
         45 64  387 23 
          6 98  215 314
        *   +   *   +  
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(4277556L, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(3263827L, Solution.RunPart2(ExampleInput));
    }
}
