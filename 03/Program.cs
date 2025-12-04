// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

long total = 0;
await foreach (var bank in File.ReadLinesAsync("input"))
{
    var joltage = getHighestJoltage2(bank,12);
    Console.WriteLine(joltage);
    // break;

    total += joltage;
}
Console.WriteLine($"Total: {total}");


int getHighestJoltage(string bank)
{
    var firstDigitIndex = getIndexOfHighestDigit(bank.Substring(0, bank.Length - 1));
    var secondDigitIndex = getIndexOfHighestDigit(bank.Substring(firstDigitIndex + 1)) + firstDigitIndex + 1;
    return int.Parse($"{bank[firstDigitIndex]}{bank[secondDigitIndex]}");
}

long getHighestJoltage2(string bank, int numOfDigits)
{
    StringBuilder sb = new();
    var leftPointer = 0;
    var rightPointer = bank.Length - numOfDigits+1;
    for (int i = 0; i < numOfDigits; i++)
    {
        // Console.WriteLine($"{leftPointer} - {rightPointer}");
        var searchableSubstring = bank[leftPointer..rightPointer];
        // Console.WriteLine($"sarching in:{searchableSubstring}");
        var next = getIndexOfHighestDigit(searchableSubstring) + leftPointer;
        // Console.WriteLine($"next:{next} ({bank[next]})");

        leftPointer = next+1;
        rightPointer++;
        sb.Append(bank[next]);
    }
    return long.Parse(sb.ToString());
}

int getIndexOfHighestDigit(string text)
{
    var highest = 0;
    var currentHighestVal = int.Parse(text[0].ToString());
    for (int i = 1; i < text.Length; i++)
    {
        var c = text[i];
        var currentVal = int.Parse(c.ToString());
        if (currentVal > currentHighestVal)
        {
            highest = i;
            currentHighestVal = int.Parse(text[i].ToString());
        }
    }
    return highest;
}