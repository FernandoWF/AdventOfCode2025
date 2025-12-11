namespace Solutions.Day11;

internal sealed partial class Solution : ISolution
{
    public static object RunPart1(Input input)
    {
        var outputLabelsByLabel = input.Lines
            .Select(line =>
            {
                var label = line[..3];
                var outputLabels = line[5..line.Length].Split(' ').ToArray();

                return (label, outputLabels);
            })
            .ToDictionary(tuple => tuple.label, tuple => tuple.outputLabels);

        return GetPathCount("you", "out", outputLabelsByLabel);
    }

    private static long GetPathCount(
        string sourceLabel,
        string targetLabel,
        Dictionary<string, string[]> outputLabelsByLabel,
        HashSet<string>? validLabels = null)
    {
        Dictionary<string, int> pathCountByProcessedLabel = [];

        int GetPathCount(string label)
        {
            if (validLabels is not null && !validLabels.Contains(label))
            {
                return 0;
            }

            if (pathCountByProcessedLabel.TryGetValue(label, out var value))
            {
                return value;
            }

            var pathCount = 0;
            foreach (var outputLabel in outputLabelsByLabel[label])
            {
                if (outputLabel == targetLabel)
                {
                    pathCount++;
                }
                else
                {
                    pathCount += GetPathCount(outputLabel);
                }
            }

            pathCountByProcessedLabel.Add(label, pathCount);
            return pathCount;
        }

        return GetPathCount(sourceLabel);
    }

    public static object RunPart2(Input input)
    {
        var outputLabelsByLabel = input.Lines
            .Select(line =>
            {
                var label = line[..3];
                var outputLabels = line[5..line.Length].Split(' ').ToArray();

                return (label, outputLabels);
            })
            .ToDictionary(tuple => tuple.label, tuple => tuple.outputLabels);

        Dictionary<string, HashSet<string>> predecessorLabelsByLabel = [];
        foreach (var (label, outputLabels) in outputLabelsByLabel)
        {
            foreach (var outputLabel in outputLabels)
            {
                predecessorLabelsByLabel.TryAdd(outputLabel, []);
                predecessorLabelsByLabel[outputLabel].Add(label);
            }
        }

        // The input file has zero paths from dac to fft
        // It only has paths from fft to dac
        // This means every path has to pass first by fft and then by dac
        // So it is possible to calculate separately svr -> fft, fft -> dac, dac -> out

        var validLabelsToFft = GetValidLabels("fft", predecessorLabelsByLabel);
        var validLabelsToDac = GetValidLabels("dac", predecessorLabelsByLabel);

        var pathCountToFft = GetPathCount("svr", "fft", outputLabelsByLabel, validLabelsToFft);
        var pathCountToDac = GetPathCount("fft", "dac", outputLabelsByLabel, validLabelsToDac);
        var pathCountToOut = GetPathCount("dac", "out", outputLabelsByLabel);

        return pathCountToFft * pathCountToDac * pathCountToOut;
    }

    private static HashSet<string> GetValidLabels(string targetLabel, Dictionary<string, HashSet<string>> predecessorLabelsByLabel)
    {
        var validLabels = new HashSet<string> { targetLabel };
        var additionalValidLabels = new HashSet<string>();

        var previousValidLabelCount = -1;
        var currentValidLabelCount = 0;

        while (currentValidLabelCount > previousValidLabelCount)
        {
            previousValidLabelCount = currentValidLabelCount;

            foreach (var label in validLabels)
            {
                if (predecessorLabelsByLabel.TryGetValue(label, out var predecessorLabels))
                {
                    foreach (var predecessorLabel in predecessorLabels)
                    {
                        additionalValidLabels.Add(predecessorLabel);
                    }
                }
            }

            validLabels.UnionWith(additionalValidLabels);
            additionalValidLabels.Clear();
            currentValidLabelCount = validLabels.Count;
        }

        return validLabels;
    }
}
