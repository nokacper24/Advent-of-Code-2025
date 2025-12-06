// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

Console.WriteLine("Hello, World!");


await solve1();
async Task solve1()
{

    string[][] worksheet = [];

    await foreach (var line in File.ReadLinesAsync("testinput"))
    {
        Regex regex = new("[ ]{2,}", RegexOptions.None);
        var normalizedLine = regex.Replace(line, " ").Trim();
        worksheet = [.. worksheet, normalizedLine.Split(' ')];
    }
    long total = 0;
    for (int i = 0; i < worksheet[0].Length; i++)
    {
        long[] values = [];
        for (int j = 0; j < worksheet.Length - 1; j++)
        {
            var stringVal = worksheet[j][i];
            values = [.. values, long.Parse(stringVal)];
        }
        string operaion = worksheet[worksheet.Length - 1][i];
        if (operaion == "+")
        {
            total += values.Aggregate((a, c) => a + c);
        }
        else
        {
            total += values.Aggregate((a, c) => a * c);
        }
    }
    Console.WriteLine(total);
}


await solve2();
async Task solve2()
{

    Problem[] worksheet = [];

    var lines = await File.ReadAllLinesAsync("input");
    var height = lines.Length;

    var problem = new Problem();

    for (int x = 0; x < lines[0].Length; x++)
    {
        StringBuilder sb = new();
        for (int y = 0; y < height; y++)
        {
            var c = lines[y][x];
            Console.WriteLine($"Looking at [{c}]");

            if (y == height - 1 && c != ' ')
            {
                if (problem.Values.Length != 0)
                {
                    worksheet = [.. worksheet, problem];
                }
                problem = new Problem
                {
                    Sign = c
                };
            }
            else if (c != ' ')
            {
                sb.Append(c);
            }
        }
        if (!string.IsNullOrEmpty(sb.ToString()))
        {
            problem.Values = [.. problem.Values, long.Parse(sb.ToString())];
        }
        sb.Clear();
    }
    worksheet = [.. worksheet, problem];
    
    long total = 0;
    foreach (var p in worksheet)
    {
        Console.WriteLine(p);
        if (p.Sign == '+')
        {
            total += p.Values.Aggregate((a, c) => a + c);
        }
        else
        {
            total += p.Values.Aggregate((a, c) => a * c);
        }
    }
    Console.WriteLine(total);

}

record Problem
{
    public char Sign { get; set; }
    public long[] Values { get; set; } = [];

    public override string ToString()
    {
        return $"{{ Sign = {Sign}, Values = [{string.Join(", ", Values)}] }}";
    }
}