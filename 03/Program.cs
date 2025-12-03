// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var total = 0;
await foreach (var bank in File.ReadLinesAsync("input"))
{
    var joltage = getHighestJoltage(bank);
    Console.WriteLine(joltage);

    total += joltage;
}
Console.WriteLine(total);


int getHighestJoltage(string bank)
{
    var firstDigitIndex = getIndexOfHighestDigit(bank.Substring(0, bank.Length - 1));
    var secondDigitIndex = getIndexOfHighestDigit(bank.Substring(firstDigitIndex+1)) + firstDigitIndex + 1;
    return int.Parse($"{bank[firstDigitIndex]}{bank[secondDigitIndex]}");
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