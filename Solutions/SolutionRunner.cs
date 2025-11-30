using System.Diagnostics;
using System.Reflection;

namespace Solutions;

internal static class SolutionRunner
{
    public static void Run<TSolution>() where TSolution : ISolution
    {
        var input = InputFetcher.Fetch<TSolution>().GetAwaiter().GetResult();

        var stopwatch = new Stopwatch();
        Console.WriteLine("========== Part 1 ==========");

        stopwatch.Start();
        var output = TSolution.RunPart1(input);
        stopwatch.Stop();

        Console.WriteLine(output?.ToString());
        Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");

        Console.WriteLine();
        Console.WriteLine("========== Part 2 ==========");

        stopwatch.Restart();
        output = TSolution.RunPart2(input);
        stopwatch.Stop();

        Console.WriteLine(output?.ToString());
        Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");
    }

    public static void RunLast()
    {
        var interfaceType = typeof(ISolution);
        var lastSolutionType = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsAssignableTo(interfaceType) && t != interfaceType)
            .OrderByDescending(s => s.Namespace)
            .First();

        typeof(SolutionRunner)
            .GetMethod(nameof(Run))!
            .MakeGenericMethod(lastSolutionType)
            .Invoke(null, null);
    }
}
