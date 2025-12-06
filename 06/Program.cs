// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string[][] worksheet = [];

await foreach (var line in File.ReadLinesAsync("input"))
{
    Regex regex = new("[ ]{2,}", RegexOptions.None);
    var normalizedLine = regex.Replace(line, " ").Trim();
    worksheet = [.. worksheet, normalizedLine.Split(' ')];
}

solve1();
void solve1()
{
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