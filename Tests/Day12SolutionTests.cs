using Solutions;
using Solutions.Day12;

namespace Tests;

public class Day12SolutionTests
{
    private static readonly Input ExampleInput = new("""
        0:
        ###
        ##.
        ##.

        1:
        ###
        ##.
        .##

        2:
        .##
        ###
        ##.

        3:
        ##.
        ###
        ##.

        4:
        ###
        #..
        ###

        5:
        ###
        .#.
        ###

        4x4: 0 0 0 0 2 0
        12x5: 1 0 1 0 2 2
        12x5: 1 0 1 0 3 2
        """);

    [Fact]
    public void RunPart1_ExampleInput_ReturnsCorrectOutput()
    {
        // This fails but it works on the real input ¯\_(ツ)_/¯
        Assert.Equal(2, Solution.RunPart1(ExampleInput));
    }

    [Fact]
    public void RunPart2_ExampleInput_ReturnsCorrectOutput()
    {
        Assert.Equal("There is no part 2!", Solution.RunPart2(ExampleInput));
    }
}
