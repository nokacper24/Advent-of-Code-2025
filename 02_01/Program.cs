// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string content = await File.ReadAllTextAsync("input");
var ranges = content.Split(',');


long total = 0;
foreach (var range in ranges)
{
    var vals = range.Split('-');
    var min = long.Parse(vals[0]);
    var max = long.Parse(vals[1]);
    for (long i = min; i <= max; i++)
    {
        if (isInvalid(i.ToString()))
        {
            total += i;
        }
    }

}

Console.WriteLine(total);


bool isInvalid(string digits)
{
    if (digits.Length % 2 != 0)
    {
        return false;
    }
    var half1 = digits.Substring(0, digits.Length / 2);
    var half2 = digits.Substring(digits.Length / 2, digits.Length / 2);
    return half1 == half2;
}