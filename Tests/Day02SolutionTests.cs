using Solutions;
using Solutions.Day02;

namespace Tests;

public class Day02SolutionTests
{
    private static readonly Input ExampleInput = new("""
        11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(1227775554L, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal(4174379265L, Solution.RunPart2(ExampleInput));
    }
}
