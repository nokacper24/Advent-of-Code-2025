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

solve1();
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