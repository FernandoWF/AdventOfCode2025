using Solutions;
using Solutions.Day10;

namespace Tests;

public class Day10SolutionTests
{
    private static readonly Input ExampleInput = new("""
        [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
        [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
        [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(7, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(33, Solution.RunPart2(ExampleInput));
    }
}
