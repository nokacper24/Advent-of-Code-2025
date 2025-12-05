// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;

Console.WriteLine("Hello, World!");

List<long[]> ranges = [];
List<long> ids = [];

bool loadingRanges = true;
await foreach (var line in File.ReadLinesAsync("input"))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        loadingRanges = false;
        continue;
    }
    if (loadingRanges)
    {
        var splitLine = line.Split('-');
        ranges.Add([long.Parse(splitLine[0]), long.Parse(splitLine[1])]);
    }
    else
    {
        ids.Add(long.Parse(line));
    }
}

// solve1();
void solve1()
{
    long freshCount = 0;
    foreach (var id in ids)
    {
        if (ranges.Any(range => id >= range[0] && id <= range[1]))
        {
            freshCount++;
        }
    }
    Console.WriteLine(freshCount);
}

solve2();
void solve2()
{
    long total = 0;
    ranges.Sort((a, b) => a[0].CompareTo(b[0]));
    long leftPointer = ranges[0][0];
    long rightPointer = ranges[0][1];

    for (int i = 1; i < ranges.Count; i++)
    {
        var range = ranges[i];
        var start = range[0];
        var end = range[1];

        if (start > rightPointer + 1)
        {
            Console.WriteLine($"{leftPointer}-{rightPointer}");
            total += rightPointer - leftPointer + 1;

            leftPointer = start;
            rightPointer = end;
        }
        else if (end > rightPointer)
        {
            rightPointer = end;
        }
    }
    Console.WriteLine($"{leftPointer}-{rightPointer}");
    total += rightPointer - leftPointer + 1;

    Console.WriteLine(total);

}