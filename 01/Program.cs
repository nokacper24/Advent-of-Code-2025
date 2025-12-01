// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var atZeroCount = 0;
var position = 50;
await foreach (var line in File.ReadLinesAsync("input"))
{
    var positionbefore = position;
    var direction = line.FirstOrDefault();
    var amount = int.Parse(line.Substring(1));
    if (direction == 'R')
    {
        position = (position + amount) % 100;
    }
    else if (direction == 'L')
    {
        position = (position - amount) % 100;
    }
    else
    {
        throw new Exception("invalid direction");
    }
    if (position == 0)
    {
        atZeroCount++;
    }
    Console.WriteLine($"{positionbefore} -> {direction}{amount} -> {position}");

}

Console.WriteLine(atZeroCount);


