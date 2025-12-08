namespace Solutions.Day08;

internal sealed class Solution : ISolution
{
    static object ISolution.RunPart1(Input input) => RunPart1(input);

    public static object RunPart1(Input input, int pairsToConnect = 1000)
    {
        ParseData(input, out var distanceByJunctionBoxPair, out var circuitByJunctionBox);

        foreach (var (junctionBoxPair, distance) in distanceByJunctionBoxPair.OrderBy(pair => pair.Value).Take(pairsToConnect))
        {
            if (circuitByJunctionBox[junctionBoxPair.JunctionBox1] != circuitByJunctionBox[junctionBoxPair.JunctionBox2])
            {
                var newCircuit = circuitByJunctionBox[junctionBoxPair.JunctionBox1];
                var oldCircuit = circuitByJunctionBox[junctionBoxPair.JunctionBox2];

                foreach (var junctionBox in oldCircuit)
                {
                    newCircuit.Add(junctionBox);
                    circuitByJunctionBox[junctionBox] = newCircuit;
                }
            }
        }

        return circuitByJunctionBox.Values
            .Distinct()
            .OrderByDescending(circuit => circuit.Count)
            .Take(3)
            .Aggregate(1, (result, circuit) => result * circuit.Count);
    }

    private static void ParseData(
        Input input,
        out Dictionary<(Position JunctionBox1, Position JunctionBox2), double> distanceByJunctionBoxPair,
        out Dictionary<Position, HashSet<Position>> circuitByJunctionBox)
    {
        var junctionBoxes = input.Lines
            .Select(line =>
            {
                var rawCoordinates = line.Split(',');
                return new Position(int.Parse(rawCoordinates[0]), int.Parse(rawCoordinates[1]), int.Parse(rawCoordinates[2]));
            })
            .ToList();

        distanceByJunctionBoxPair = [];
        foreach (var junctionBox in junctionBoxes)
        {
            foreach (var otherJunctionBox in junctionBoxes)
            {
                if (junctionBox != otherJunctionBox
                    && !distanceByJunctionBoxPair.ContainsKey((junctionBox, otherJunctionBox))
                    && !distanceByJunctionBoxPair.ContainsKey((otherJunctionBox, junctionBox)))
                {
                    var distance = junctionBox.GetDistanceTo(otherJunctionBox);
                    distanceByJunctionBoxPair.Add((junctionBox, otherJunctionBox), distance);
                }
            }
        }

        circuitByJunctionBox = junctionBoxes.ToDictionary(
            junctionBox => junctionBox,
            junctionBox => new HashSet<Position> { junctionBox });
    }

    public static object RunPart2(Input input)
    {
        ParseData(input, out var distanceByJunctionBoxPair, out var circuitByJunctionBox);
        var circuits = circuitByJunctionBox.Values.ToHashSet();
        (Position JunctionBox1, Position JunctionBox2) lastConnectedPair = default;

        foreach (var (junctionBoxPair, distance) in distanceByJunctionBoxPair.OrderBy(pair => pair.Value))
        {
            if (circuitByJunctionBox[junctionBoxPair.JunctionBox1] != circuitByJunctionBox[junctionBoxPair.JunctionBox2])
            {
                var newCircuit = circuitByJunctionBox[junctionBoxPair.JunctionBox1];
                var oldCircuit = circuitByJunctionBox[junctionBoxPair.JunctionBox2];

                foreach (var junctionBox in oldCircuit)
                {
                    newCircuit.Add(junctionBox);
                    circuitByJunctionBox[junctionBox] = newCircuit;
                }

                circuits.Remove(oldCircuit);
                lastConnectedPair = junctionBoxPair;
            }

            if (circuits.Count == 1)
            {
                break;
            }
        }

        return lastConnectedPair.JunctionBox1.X * lastConnectedPair.JunctionBox2.X;
    }
}
