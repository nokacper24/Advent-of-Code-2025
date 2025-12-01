// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int atZeroCount = 0;
int position = 50;
await foreach (var line in File.ReadLinesAsync("input"))
{
    var positionbefore = position;
    var direction = line.FirstOrDefault();
    int amount = int.Parse(line.Substring(1));
    int modifier = 1;
    if (direction == 'L')
    {
        modifier = -1;
    }

    int relevantAmount = amount % 100;
    int fullRotations = amount / 100;
    int targetPosition = position + (relevantAmount * modifier);
    position = ((targetPosition % 100) + 100) % 100;


    atZeroCount += fullRotations;

    var passedZero = positionbefore != 0 && position != 0 &&(targetPosition >= 100 || targetPosition < 0);
    if (passedZero)
    {
        atZeroCount++;
    }
    if (position == 0)
    {
        atZeroCount++;
    }
    Console.WriteLine($"{positionbefore} -> {direction}{amount} -> {position}, full rotatios {fullRotations}, passed0: {passedZero}");

}

Console.WriteLine(atZeroCount);


